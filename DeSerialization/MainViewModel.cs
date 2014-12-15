using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;

namespace DeSerialization
{
    class MainViewModel:NotificationObject
    {
        private Hashtable modelContext;
        public Hashtable ModelContext
        {
            get { return modelContext; }
            set
            {
                if (modelContext != value)
                {
                    modelContext = value;
                    RaisePropertyChanged("ModelContext");
                }
            }
        }

        private string name;
        public string Name
        {
            get{return name;}
            set{
                if(name!=value)
                {
                name=value;
                RaisePropertyChanged("Name");
                }
            }
        }

        private string email;
        public string Email
        {
            get{return email;}
            set{
                if(email!=value)
                {
                email=value;
                RaisePropertyChanged("Email");
                }
            }
        }

        private string all;
        public string All
        {
            get{
                return all;
            }

            set
            {
                if(all!=value)
                {
                    all=value;
                    RaisePropertyChanged("All");
                }
            }
        }




        public DelegateCommand AddCommand { get; set; }

        private void add()
        {
            All = Name + Email;
        }

        public MainViewModel()
        {
            AddCommand = new DelegateCommand(new Action(add));
        }

        public MainViewModel(string InXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(InXml);
            ModelContext = new Hashtable();
            XmlNodeList nodeList = doc.ChildNodes;
            foreach (XmlNode rootNode in nodeList)
            {
                if (rootNode.NodeType.ToString() == "Element")
                {
                    string path = rootNode.Name;
                    XmlToHastTable(rootNode, ModelContext, path);
                }
 
            }     

            AddCommand = new DelegateCommand(new Action(add));
        }

        private void XmlToHastTable(XmlNode rootNode,Hashtable ht,string path)
        {
            
            if(rootNode.HasChildNodes)
            {
                XmlNodeList nodeList = rootNode.ChildNodes;
                foreach (XmlNode aNode in nodeList)
                {
                    string relativePath = path;
                    relativePath += "." + aNode.Name;
                    if (aNode.HasChildNodes)
                    {
                        
                        XmlNode endNote = aNode.FirstChild;
                        if (endNote.NodeType.ToString() == "Text")
                        {
                            ht[relativePath] = aNode.InnerText.ToString();

                        }
                        else
                        {
                            XmlToHastTable(aNode, ht, relativePath);
                        }
                    }
                    else
                    {
                        ht[relativePath] = "";                        
                    }

                }
            }
 
        }


    }
}
