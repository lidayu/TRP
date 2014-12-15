using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DeSerialization
{
    public class EqukTextBox:TextBox
    {
        private string relatedPath;
        public string RelatedPath
        {
            get;
            set;
        }
    }
}
