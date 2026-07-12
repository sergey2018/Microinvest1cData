using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microinvest1cData.Query
{
   public  class XmlGetValue
    {
        public String GetElementValue(XElement parent, XName name)
        {
            return parent?.Element(name)?.Value?.Trim() ?? string.Empty;
        }

        public double ParseDecimal(XElement parent, XName name)
        {
            var value = GetElementValue(parent, name);
            if (string.IsNullOrEmpty(value)) return 0;
            return double.TryParse(value.Replace(".", ","), out var result) ? result : 0;
        }

        public DateTime ParseDate(XElement parent, XName name)
        {
            var value = GetElementValue(parent, name);
            if (string.IsNullOrEmpty(value)) return DateTime.MinValue;
            return DateTime.TryParse(value, out var result) ? result : DateTime.MinValue;
        }
    }
}
