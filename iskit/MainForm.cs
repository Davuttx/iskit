using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iskit.Modules;
using iskit.Modules.ExcelCsv;

namespace iskit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadModuleMenu();
        }

        private readonly List<IModule> _modules = new()
{
    new ExcelCsvModule(),
};

        private void LoadModuleMenu()
        {
            foreach (var module in _modules)
            {
                lstModules.Items.Add(module.DisplayName);
            }

            if (lstModules.Items.Count > 0)
                lstModules.SelectedIndex = 0;
        }

        private void lstModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstModules.SelectedIndex;
            if (index < 0 || index >= _modules.Count) return;

            pnlContent.Controls.Clear();
            var view = _modules[index].CreateView();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
        }
    }
}
