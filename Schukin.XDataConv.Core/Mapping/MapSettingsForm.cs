using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Schukin.XDataConv.Core
{
    public partial class MapSettingsForm : Form
    {
        private readonly SaveFileDialog _saveFileDialog;
        private readonly OpenFileDialog _openFileDialog;

        public MapSettingsForm()
        {
            InitializeComponent();
            
            gridMapping.AutoGenerateColumns = false;

            buttonOk.Click += ButtonImport_Click;
            buttonSaveTemplate.Click += ButtonSaveTemplate_Click;
            buttonLoadTemplate.Click += ButtonLoadTemplate_Click;
            gridMapping.CellClick += GridMapping_CellClick;

            _saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Path.Combine(Application.StartupPath, "templates"),
                CheckPathExists = true,
                AddExtension = true,
                FileName = "template",
                Filter = "Файлы конфигурации (*.xml)|*.xml",
                DefaultExt = "xml"
            };

            _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Application.StartupPath, "templates"),
                CheckFileExists = true,
                Filter = "Файлы конфигурации (*.xml)|*.xml"
            };
        }

        public Map[] DataSource
        {
            get => gridMapping.DataSource as Map[];
            set => gridMapping.DataSource = value;
        }

        private bool ValidateForm()
        {
            var invalidMappingCompare = Core.Instance.Mapping.Where(item =>
                item.UseForCompare1 | item.UseForCompare2 && item.SourceColumnName.Trim() == "").ToArray();

            if (invalidMappingCompare.Any())
            {
                Core.Instance.ShowMessage(
                    $"Для следующих столбцов не указаны наименования столбцов файла: {String.Join(",", invalidMappingCompare.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingImport =
                Core.Instance.Mapping.Where(item => item.UseForImport && item.UseForCompare1 | item.UseForCompare2).ToArray();

            if (invalidMappingImport.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для импорта, так как они используются для идентификации: {String.Join(",", invalidMappingImport.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingImport2 =
                Core.Instance.Mapping.Where(item => item.UseForImport && item.SourceColumnName.Trim() == "").ToArray();

            if (invalidMappingImport2.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для импорта, так как для них не указаны наименования столбцов загружаемого файла: {String.Join(",", invalidMappingImport2.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingLog =
                Core.Instance.Mapping.Where(item => item.UseForLog && item.SourceColumnName.Trim() == "").ToArray();

            if (invalidMappingLog.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для отображении в протоколе, так как для них не указаны наименования столбцов загружаемого файла: {String.Join(",", invalidMappingImport2.Select(item => item.Name))}.");
                return false;
            }

            return true;
        }

        private void SaveTemplate()
        {
            if (_saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            var doc = new XDocument();
            var comment = new XComment("XDataConv configuration file v1.0 -- Schukin S.");
            var mappingsElement = new XElement("mappings");

            foreach (var item in Core.Instance.Mapping)
            {
                var mappingElement = new XElement("mapping",
                    new XAttribute("destination", item.Name),
                    new XElement("source", item.SourceColumnName),
                    new XElement("useForCompare1", item.UseForCompare1),
                    new XElement("useForCompare2", item.UseForCompare2),
                    new XElement("useForImport", item.UseForImport),
                    new XElement("useForLog", item.UseForLog)
                );

                if (item.MatchLinesCount > 0)
                {
                    var matchingsElement = new XElement("matchings");
                    
                    foreach (var matchingItem in item.MatchLines)
                    {
                        var matchingElement = new XElement("matching");

                        matchingElement.Add(
                            new XElement("destinationWord", matchingItem.AliasWord),
                            new XElement("sourceWord", matchingItem.SourceWord)
                        );

                        matchingsElement.Add(matchingElement);
                    }

                    mappingElement.Add(matchingsElement);
                }

                mappingsElement.Add(mappingElement);
            }

            doc.Add(comment, mappingsElement);
            doc.Save(_saveFileDialog.FileName);
        }

        private void LoadTemplate()
        {
            if (_openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            var doc = XDocument.Load(_openFileDialog.FileName);
            var mappingsElement = doc.Element("mappings");

            if (mappingsElement == null)
                return;

            Core.Instance.Mapping.Reset();

            foreach (var mappingElement in mappingsElement.Elements("mapping"))
            {
                var destinationAttribute = mappingElement.Attribute("destination");
                if (destinationAttribute == null)
                    continue;

                var mapping = Core.Instance.Mapping.FirstOrDefault(item => item.Name == destinationAttribute.Value);
                if (mapping == null)
                    continue;

                mapping.SourceColumnName = mappingElement.Element("source")?.Value;

                var useForCompare1Element = mappingElement.Element("useForCompare1");
                if (useForCompare1Element != null)
                {
                    bool.TryParse(useForCompare1Element.Value, out var mappingUseForCompare1);
                    mapping.UseForCompare1 = mappingUseForCompare1;
                }

                var useForCompare2Element = mappingElement.Element("useForCompare2");
                if (useForCompare2Element != null)
                {
                    bool.TryParse(useForCompare2Element.Value, out var mappingUseForCompare2);
                    mapping.UseForCompare2 = mappingUseForCompare2;
                }

                var useForImportElement = mappingElement.Element("useForImport");
                if (useForImportElement != null)
                {
                    bool.TryParse(useForImportElement.Value, out var useForImport);
                    mapping.UseForImport = useForImport;
                }

                var useForLogElement = mappingElement.Element("useForLog");
                if (useForLogElement != null)
                {
                    bool.TryParse(useForLogElement.Value, out var useForLog);
                    mapping.UseForLog = useForLog;
                }

                var matchingsElement = mappingElement.Element("matchings");
                if (matchingsElement == null)
                    continue;

                foreach (var matchingElement in matchingsElement.Elements("matching"))
                {
                    mapping.MatchLines.Add(new MatchLine
                    {
                        AliasWord = matchingElement.Element("destinationWord")?.Value,
                        SourceWord = matchingElement.Element("sourceWord")?.Value
                    });
                }
            }

            gridMapping.Invalidate();
        }

        private void GridMapping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != gridMapping.Columns["colMatchingList"].Index)
                return;

            if (!(gridMapping.Rows[e.RowIndex].DataBoundItem is Map item))
                return;

            var formMatching = new MatchSettingsForm(item.MatchLines);
            formMatching.ShowDialog();
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }

        private void ButtonLoadTemplate_Click(object sender, EventArgs e)
        {
            LoadTemplate();
        }
    }
}
