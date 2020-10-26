using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Shoprite.LPRO.LPROEntities
{
    public static class DataHelpers
    {
        public static DataSet XMLToDataSet(string xml)
        {
            DataSet ds = new DataSet();

            if (!string.IsNullOrEmpty(xml))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                XmlReader xmlReader = new XmlNodeReader(xmlDoc);

                DataTable dt = new DataTable();
                ds.ReadXml(xmlReader);
            }

            return ds;
        }

        public static XmlReader XMLToXmlReader(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                return new XmlNodeReader(xmlDoc);
 
            }

            return null;
        }

        public static XmlDocument XMLToXmlDoc(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();

            if (!string.IsNullOrEmpty(xml))
            {
                xmlDoc.LoadXml(xml);
            }

            return xmlDoc;
        }
    }
}
