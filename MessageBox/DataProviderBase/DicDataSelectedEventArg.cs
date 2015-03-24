using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageBoxTEST.DataProviderBase
{
    public class DicDataSelectedEventArg:RoutedEventArgs
    {
        public string SelectedText { get; set; }
        public string SelectedCode { get; set; }
    }
}
