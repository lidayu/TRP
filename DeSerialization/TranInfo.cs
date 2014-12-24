﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DeSerialization
{
    
    public class transaction
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Command { get; set; }
        public string Parameter { get; set; }
    }

    public class Trans
    {
        List<transaction> tranList = new List<transaction>();

        [XmlElement(ElementName = "transaction")]      
        public List<transaction> TranList
        {
            get { return tranList; }
            set { tranList = value; }
        }
    }
}
