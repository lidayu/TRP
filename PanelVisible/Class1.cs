using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PanelVisible
{
    [ValueConversion(typeof(object), typeof(object))]
    public class Class1 : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Visible;
            else
            {
                RadioButton rb = (RadioButton)value;
                if(rb.IsChecked.Value)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
