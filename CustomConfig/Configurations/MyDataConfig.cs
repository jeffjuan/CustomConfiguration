using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomConfig.Configurations
{
    //ConfigurationElement
    public class MyConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("CountyKey")]
        public string CountyKey { get { return base["CountyKey"].ToString(); } }

        [ConfigurationProperty("CountyValue")]
        public string CountyValue { get { return base["CountyValue"].ToString(); } }
    }

    //ConfigurationElementCollection
    public class MyConfigElementCollectin : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        public MyConfigElement this[int index]
        {
            get { return (MyConfigElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(MyConfigElement element)
        {
            BaseAdd(element);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MyConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyConfigElement)element).CountyKey;
        }
    }

    //ConfigurationSection
    public class MyDataConfig : ConfigurationSection
    {
        [ConfigurationProperty("MyCountyValues", IsDefaultCollection = false),
            ConfigurationCollection(typeof(MyConfigElementCollectin), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public MyConfigElementCollectin CountyCollection
        {
            get { return base["MyCountyValues"] as MyConfigElementCollectin; }
        }
    }
}