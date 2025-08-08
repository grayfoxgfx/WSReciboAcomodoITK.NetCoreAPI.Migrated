using System.Globalization;
using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class HuEnvio
    {
        private string? _material;
        private string? _hu;
        private string? _oc;

        public string? Hu
        {
            get
            {
                if (string.IsNullOrEmpty(_hu)) return string.Empty;
                int aux;
                int.TryParse(_hu, out aux);
                return aux > 0 ? _hu.Trim().ToString(CultureInfo.InvariantCulture).PadLeft(20, '0') : string.Empty;
            }
            set { _hu = value; }
        }

        public string? Material
        {
            get { return string.IsNullOrEmpty(Hu) ? _material : string.Empty; }
            set { _material = value; }
        }

        public string? Oc
        {
            get { return string.IsNullOrEmpty(Hu) ? _oc : string.Empty; }
            set { _oc = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(HuEnvio);

            var xs = new System.Xml.Serialization.XmlSerializer(output!.GetType());
            using (var sw = new System.IO.StringWriter())
            {
                try
                {
                    xs.Serialize(sw, output!);
                    objectAsXmlString = sw.ToString();
                }
                catch (Exception ex)
                {
                    objectAsXmlString = ex.ToString();
                }
            }
            return className + " --> " + objectAsXmlString;
        }
    }
}
