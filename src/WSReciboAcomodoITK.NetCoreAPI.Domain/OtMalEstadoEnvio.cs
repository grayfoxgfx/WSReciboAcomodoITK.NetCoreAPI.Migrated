using System.Globalization;
using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class OtMalEstadoEnvio
    {
        private string? _hu;
        private string? _cantidad;
        private string? _malEdo;
        private string? _motivoRech;

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

        public string? Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public string? MalEdo
        {
            get { return _malEdo; }
            set { _malEdo = value; }
        }

        public string? MotivoRech
        {
            get { return _motivoRech; }
            set { _motivoRech = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(OtMalEstadoEnvio);

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
