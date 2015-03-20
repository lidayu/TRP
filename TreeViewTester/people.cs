using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace TreeViewTester
{
    public class people
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class peoples
    {
        
        List<people> peopleList = new List<people>();

        [XmlElement(ElementName="people")]
        public List<people> PeopleList
        {
            get { return peopleList; }
            set { peopleList = value; }
        }
 
    }
    public class MoneyType
    {
        public string CCYCC { get; set; }
        public string CCYMNE { get; set; }
        public string CCYNAM { get; set; }
        public string CCYMST { get; set; }
    }
    public class MoneyTypes
    {
        List<MoneyType> moneyList = new List<MoneyType>();
        [XmlElement(ElementName = "MoneyType")]
        public List<MoneyType> MoneyList
        {
            get { return moneyList; }
            set { moneyList = value; }
        }
    }

    public class IDPublisher
    {
        public string id { get; set; }
        public string pro { get; set; }
        public string city { get; set; }
        public string area { get; set; }
    }

    public class IDPublishers
    {
        List<IDPublisher> idPublisherList = new List<IDPublisher>();
        [XmlElement(ElementName="IDPublisher")]
        public List<IDPublisher> IdPublisherList
        {
            get { return idPublisherList; }
            set { idPublisherList = value; }
        }
    }



    public class EqukCommonData
    {
        [XmlElement(ElementName="peoples")]
        public peoples PeoplesList { get; set; }

        [XmlElement(ElementName = "MoneyTypes")]
        public MoneyTypes MoneysList { get; set; }

        [XmlElement(ElementName="IDPublishers")]
        public IDPublishers IdPublishersList { get; set; }
 
    }

}
