using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageBoxTEST.DataProviderBase
{
    public class DataSelectWindowBase:Window
    {
        public delegate void DataSelectedEventHandler(object sender, DicDataSelectedEventArg e);
        public event DataSelectedEventHandler AfterSelectEvent;
  
        public void OnAfterSelect(DicDataSelectedEventArg e)
        {
            this.AfterSelectEvent(this, e);
        
        }

   }
}
