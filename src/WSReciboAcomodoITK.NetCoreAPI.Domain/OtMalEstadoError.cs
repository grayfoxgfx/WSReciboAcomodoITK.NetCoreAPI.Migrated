using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class OtMalEstadoError
    {
        private string? _hu;
        private string? _error;
        private string? _descripError;

        public string? Hu
        {
            get { return _hu; }
            set { _hu = value; }
        }

        public string? Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public string? DescripError
        {
            get { return _descripError; }
            set { _descripError = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(OtMalEstadoError);

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
