using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MessageBoxTEST
{
    public class EqukTextBox:TextBox
    {
        public EqukTextBox()
        {
            this.IsReadOnly = true;
            this.GotFocus += EqukTextBoxGotFocus;
        }

        private void EqukTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            DataSelectWindow dataWindow = new DataSelectWindow();
            dataWindow.AfterSelect += ReceiveData;
            dataWindow.ShowDialog();            
        }

        private void ReceiveData(object sender, DicDataSelectedEventArg e)
        {
            this.Text = e.SelectedText;
        }
    }
}
