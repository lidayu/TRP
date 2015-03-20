using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using MessageBoxTEST;

namespace ReflectionOtherWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Assembly dataWin = Assembly.LoadFrom("MessageBox.dll");
            Type dataWinType = dataWin.GetType("MessageBoxTEST.DataSelectWindow");
            DataSelectWindow dataWindow = Activator.CreateInstance(dataWinType) as DataSelectWindow;
            dataWindow.AfterSelect += setMainWindowValue;
            dataWindow.ShowDialog();
            
            

        }
        
        private void setMainWindowValue(object sender,DicDataSelectedEventArg e)
        {
            this.textBox1.Text = e.SelectedText;
        }
    }
}
