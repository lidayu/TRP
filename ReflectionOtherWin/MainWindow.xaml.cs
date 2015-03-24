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
using MessageBoxTEST.DataProviderBase;

namespace ReflectionOtherWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object fieldNeededData = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            fieldNeededData = sender;
            Assembly dataWin = Assembly.LoadFrom("MessageBox.dll");
            Type dataWinType = dataWin.GetType("MessageBoxTEST.DataSelectWindow");
            DataSelectWindowBase dataWindow = Activator.CreateInstance(dataWinType) as DataSelectWindowBase;
            dataWindow.AfterSelectEvent += setMainWindowValue;
            dataWindow.ShowDialog();
            
            

        }
        
        private void setMainWindowValue(object sender,DicDataSelectedEventArg e)
        {

            TextBox focusedTextBox = fieldNeededData as TextBox;
           focusedTextBox.Text = e.SelectedText;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DataUsercontrolWin dddd = new DataUsercontrolWin();
            dddd.BringIntoView();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DataSelectWindow win = new DataSelectWindow();
            win.ShowDialog();
        }
    }
}
