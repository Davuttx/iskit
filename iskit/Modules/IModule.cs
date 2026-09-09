using System;
using System.Collections.Generic;
using System.Text;

namespace iskit.Modules
{
    public interface IModule
    {
        string DisplayName { get; }
        UserControl CreateView();
    }
}
