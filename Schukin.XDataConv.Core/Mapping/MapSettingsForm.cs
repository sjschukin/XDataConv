using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Schukin.XDataConv.Core
{
    public partial class MapSettingsForm : Form
    {
        private readonly MapSettings _mapSettings;
        private readonly SaveFileDialog _saveFileDialog;
        private readonly OpenFileDialog _openFileDialog;

        public MapSettingsForm(MapSettings mapSettings)
        {
            InitializeComponent();

            _mapSettings = mapSettings;

            gridMapping.AutoGenerateColumns = false;
            gridMapping.DataSource = mapSettings.Mapping.ToArray();

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
                Filter = "Файлы шаблонов XDataConv (*.xml)|*.xml",
                DefaultExt = "xml"
            };

            _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Application.StartupPath, "templates"),
                CheckFileExists = true,
                Filter = "Файлы шаблонов XDataConv (*.xml)|*.xml"
            };
        }

        private bool ValidateForm()
        {
            var invalidMappingCompare = _mapSettings.Mapping.Where(item =>
                item.IsUseForCompare1 | item.IsUseForCompare2 && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingCompare.Any())
            {
                Core.Instance.ShowMessage(
                    $"Для следующих столбцов не указаны наименования столбцов файла: {String.Join(",", invalidMappingCompare.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingInject =
                _mapSettings.Mapping.Where(item => item.IsUseForInject && item.IsUseForCompare1 | item.IsUseForCompare2).ToArray();

            if (invalidMappingInject.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для копирования в источник, так как они используются для идентификации: {String.Join(",", invalidMappingInject.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingInject2 =
                _mapSettings.Mapping.Where(item => item.IsUseForInject && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingInject2.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для копирования в источник, так как для них не указаны наименования столбцов загружаемого файла: {String.Join(",", invalidMappingInject2.Select(item => item.Name))}.");
                return false;
            }

            var invalidMappingLog =
                _mapSettings.Mapping.Where(item => item.IsUseForLog && String.IsNullOrWhiteSpace(item.ImportFieldName)).ToArray();

            if (invalidMappingLog.Any())
            {
                Core.Instance.ShowMessage(
                    $"Следующие столбцы не могут быть использованы для отображении в протоколе, так как для них не указаны наименования столбцов загружаемого файла: {String.Join(",", invalidMappingInject2.Select(item => item.Name))}.");
                return false;
            }

            return true;
        }

        private void SaveTemplate()
        {
            if (_saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            var doc = new XDocument();
            var comment = new XComment("XDataConv configuration file v2.1 -- Schukin S.");

            var mappingsElement = new XElement("mappings");

            var settingElement = new XElement("setting",
                new XAttribute("name", "isFindAllMatches"),
                _mapSettings.IsFindAllMatches
            );

            mappingsElement.Add(settingElement);

            foreach (var item in _mapSettings.Mapping)
            {
                var mappingElement = new XElement("mapping",
                    new XAttribute("name", item.Name),
                    new XElement("importFieldName", item.ImportFieldName),
                    new XElement("isConvertImportToUpperCase", item.IsConvertImportToUpperCase),
                    new XElement("isUseForCompare1", item.IsUseForCompare1),
                    new XElement("isUseForCompare2", item.IsUseForCompare2),
                    new XElement("isUseForInject", item.IsUseForInject),
                    new XElement("isUseForLog", item.IsUseForLog)
                );

                if (item.ImportMatchLinesCount > 0)
                {
                    var matchingsElement = new XElement("matchings");

                    foreach (var matchingItem in item.ImportMatchLines)
                    {
                        var matchingElement = new XElement("matching");

                        matchingElement.Add(
                            new XElement("sourceWord", matchingItem.SourceWord),
                            new XElement("aliasWord", matchingItem.AliasWord)
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

            var xml = XDocument.Load(_openFileDialog.FileName);

            var mappingsElement = xml.Element("mappings");

            if (mappingsElement == null)
                return;

            foreach (var settingElement in mappingsElement.Elements("setting"))
            {
                if (settingElement.Attribute("name")?.Value == "isFindAllMatches")
                {
                    bool.TryParse(settingElement.Value, out var isFindAllMatches);
                    _mapSettings.IsFindAllMatches = isFindAllMatches;
                }
            }

                _mapSettings.Mapping.Reset();

            foreach (var mappingElement in mappingsElement.Elements("mapping"))
            {
                var nameAttribute = mappingElement.Attribute("name");
                if (nameAttribute == null)
                    continue;

                var mapping = _mapSettings.Mapping.FirstOrDefault(item => item.Name == nameAttribute.Value);
                if (mapping == null)
                    continue;

                mapping.ImportFieldName = mappingElement.Element("importFieldName")?.Value;

                var isConvertImportToUpperCaseElement = mappingElement.Element("isConvertImportToUpperCase");
                if (isConvertImportToUpperCaseElement != null)
                {
                    bool.TryParse(isConvertImportToUpperCaseElement.Value, out var mappingIsConvertImportToUpperCase);
                    mapping.IsConvertImportToUpperCase = mappingIsConvertImportToUpperCase;
                }

                var isUseForCompare1Element = mappingElement.Element("isUseForCompare1");
                if (isUseForCompare1Element != null)
                {
                    bool.TryParse(isUseForCompare1Element.Value, out var mappingIsUseForCompare1);
                    mapping.IsUseForCompare1 = mappingIsUseForCompare1;
                }

                var isUseForCompare2Element = mappingElement.Element("isUseForCompare2");
                if (isUseForCompare2Element != null)
                {
                    bool.TryParse(isUseForCompare2Element.Value, out var mappingIsUseForCompare2);
                    mapping.IsUseForCompare2 = mappingIsUseForCompare2;
                }

                var isUseForInjectElement = mappingElement.Element("isUseForInject");
                if (isUseForInjectElement != null)
                {
                    bool.TryParse(isUseForInjectElement.Value, out var isUseForInject);
                    mapping.IsUseForInject = isUseForInject;
                }

                var isUseForLogElement = mappingElement.Element("isUseForLog");
                if (isUseForLogElement != null)
                {
                    bool.TryParse(isUseForLogElement.Value, out var isUseForLog);
                    mapping.IsUseForLog = isUseForLog;
                }

                var matchingsElement = mappingElement.Element("matchings");
                if (matchingsElement == null)
                    continue;

                foreach (var matchingElement in matchingsElement.Elements("matching"))
                {
                    mapping.ImportMatchLines.Add(new MatchLine
                    {
                        SourceWord = matchingElement.Element("sourceWord")?.Value,
                        AliasWord = matchingElement.Element("aliasWord")?.Value
                    });
                }
            }

            gridMapping.Invalidate();
        }

        private void ShowMatchSettingsForm(MapItem mapItem)
        {
            var formMatching = new MatchSettingsForm(mapItem);
            formMatching.ShowDialog();
        }

        private void GridMapping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var matchingColumn = gridMapping.Columns["colMatchingList"];

            if (matchingColumn == null)
                return;

            if (e.RowIndex < 0 || e.ColumnIndex != matchingColumn.Index)
                return;

            if (!(gridMapping.Rows[e.RowIndex].DataBoundItem is MapItem item))
                return;

            if (((System.Reflection.PropertyInfo)item.MemberInfo).PropertyType.Name != "String")
                return;

            ShowMatchSettingsForm(item);
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
