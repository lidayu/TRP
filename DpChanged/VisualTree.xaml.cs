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
using System.Windows.Shapes;

namespace DpChanged
{
    /// <summary>
    /// Interaction logic for VisualTree.xaml
    /// </summary>
    public partial class VisualTree : Window
    {
        public VisualTree()
        {
            InitializeComponent();
            
        }

        private void GetViewData(Visual myVisual)
        {
            int controlCount = VisualTreeHelper.GetChildrenCount(myVisual);

            for (int i = 0; i < controlCount; i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                if (childVisual != null)
                {
                    if (childVisual is TextBox)
                    {
                        TextBox childTextBox = childVisual as TextBox;
                        //equkData.Add(childTextBox.Name, childTextBox.Text);
                        childTextBox.IsEnabled = false;
                    }
                    else if (childVisual is RadioButton)
                    {
                        RadioButton childRadioButton = childVisual as RadioButton;
                       
                        childRadioButton.IsEnabled = false;
                    }
                    else if (childVisual is CheckBox)
                    {
                        CheckBox childCB = childVisual as CheckBox;
                        
                        childCB.IsEnabled = false;
                    }
                    else if (childVisual is StackPanel)
                    {
                        StackPanel dddSP = new StackPanel();

                    }
                    else if (childVisual is Label)
                    {
                        Label childLb = childVisual as Label;
                        string childLbTxt = childLb.Content.ToString();
                    }
                    else if (childVisual is ComboBox)
                    {
                        ComboBox childComboBox = childVisual as ComboBox;
                        childComboBox.IsEnabled = false;
                    }
                    else
                        GetViewData(childVisual);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetViewData((Visual)this);
        }
    }
}
