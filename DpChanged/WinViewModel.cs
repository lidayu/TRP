using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DpChanged
{
    public class WinViewModel:DependencyObject
    {
        public WinViewModel()
        { }


        public string text1
        {
            get { return (string)GetValue(text1Property); }
            set { SetValue(text1Property, value); }
        }

        // Using a DependencyProperty as the backing store for text1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty text1Property =
            DependencyProperty.Register("text1", typeof(string), typeof(WinViewModel), 
            new PropertyMetadata(OnText1Changed));

        private static void OnText1Changed(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as WinViewModel).OnText1Changed(args);
        }
        void OnText1Changed(DependencyPropertyChangedEventArgs args)
        {
            this.text2 = "中南海紫光阁";
        }

        public string text2
        {
            get { return (string)GetValue(text2Property); }
            set { SetValue(text2Property, value); }
        }

        // Using a DependencyProperty as the backing store for text2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty text2Property =
            DependencyProperty.Register("text2", typeof(string), typeof(WinViewModel), new UIPropertyMetadata("lidayu"));

        

        

    }
}
