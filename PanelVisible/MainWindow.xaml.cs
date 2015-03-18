﻿using System;
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

namespace PanelVisible
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Grid aGrid=(Grid)this.textBox1.Parent;
            GroupBox gb = (GroupBox)aGrid.Parent;
            if (gb.Visibility == Visibility.Collapsed)
                MessageBox.Show("no check");
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
             this.groupBox1.Visibility = Visibility.Visible;
             this.groupBox1.IsEnabled = false;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            //this.groupBox1.Visibility = Visibility.Collapsed;
        }
    }
}
