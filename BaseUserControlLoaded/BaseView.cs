using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace BaseUserControlLoaded.Base
{
    public class EqukDatePicker : DatePicker
    {
 
    }
    public class BaseView:UserControl
    {
        public BaseView()
        {
            this.Loaded += ViewLoaded;
            //this.Initialized += ViewLoaded;

 
        }
        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            Visual visualSender = (Visual)sender;
            LoadViewData(visualSender);
            
        }
        private void LoadViewData(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                if (childVisual is TextBox)
                {
                    TextBox childTextBox = childVisual as TextBox;
                    childTextBox.Text = "superman";
                }
                else
                {
                    LoadViewData(childVisual);
                }
            }
        }
    }
}
