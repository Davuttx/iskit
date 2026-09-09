using System;
using System.Collections.Generic;
using System.Text;

namespace iskit.Modules.ExcelCsv
{
    public class ExcelCsvModule : IModule
    {
        public string DisplayName => "📊  Excel / CSV Aracı";
        public UserControl CreateView() => new ExcelCsvView();
    }
}