using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class HuError
    {
        private string? _error;
        private bool _isError;

        public string? Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public bool IsError
        {
            get { return _isError; }
            set { _isError = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(HuError);

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
