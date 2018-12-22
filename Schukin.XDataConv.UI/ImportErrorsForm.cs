using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Schukin.XDataConv.Core.Interfaces;

namespace Schukin.XDataConv.UI
{
    public partial class ImportErrorsForm : Form
    {
        public delegate void ItemActivatedEventHandler(object sender, IDataItemError itemError);
        public event ItemActivatedEventHandler ItemActivated;

        public ImportErrorsForm()
        {
            InitializeComponent();

            FormClosing += (sender, args) =>
            {
                Hide();
                args.Cancel = true;
            };

            lvMain.ItemActivate += OnItemActivate;
        }

        public void PopulateData(IDataItemError item)
        {
            lvMain.Items.Add(new ListViewItem(new[] {item.RowId.ToString(), item.Message}) {Tag = item});
        }

        public void PopulateData(IEnumerable<IDataItemError> items)
        {
            lvMain.SuspendLayout();
            lvMain.Items.AddRange(items
                .Select(item => new ListViewItem(new[] {item.RowId.ToString(), item.Message}) {Tag = item}).ToArray());
            lvMain.ResumeLayout();
        }

        public void Clear()
        {
            lvMain.Items.Clear();
        }

        private void OnItemActivate(object sender, EventArgs e)
        {
            if (lvMain.SelectedItems.Count !=1)
                return;

            var selectedItem = lvMain.SelectedItems[0];

            ItemActivated?.Invoke(this, (IDataItemError) selectedItem.Tag);
        }
    }
}
