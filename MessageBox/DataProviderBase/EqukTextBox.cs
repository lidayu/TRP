using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Reflection;

namespace MessageBoxTEST.DataProviderBase
{
    public class EqukTextBox:TextBox
    {
        public EqukTextBox()
        {
            this.IsReadOnly = true;
            //this.GotFocus += EqukTextBoxGotFocus;
            this.PreviewMouseDown+=textBox1_PreviewMouseDown;
        }
        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            Assembly dataWin = Assembly.LoadFrom("MessageBox.dll");
            Type dataWinType = dataWin.GetType("MessageBoxTEST.DataSelectWindow");
            DataSelectWindowBase dataWindow = Activator.CreateInstance(dataWinType) as DataSelectWindowBase;
            dataWindow.AfterSelectEvent += setMainWindowValue;
            dataWindow.ShowDialog();

        }

        private void setMainWindowValue(object sender, DicDataSelectedEventArg e)
        {

            //TextBox focusedTextBox = fieldNeededData as TextBox;
            this.Text = e.SelectedText;
        }

        private void EqukTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            //DataSelectWindow dataWindow = new DataSelectWindow();
            //dataWindow.AfterSelect += ReceiveData;
            //dataWindow.ShowDialog();            
        }

        private void ReceiveData(object sender, DicDataSelectedEventArg e)
        {
            this.Text = e.SelectedText;
        }
    }
}
