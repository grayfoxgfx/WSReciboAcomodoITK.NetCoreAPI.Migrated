using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class User
    {
        private string? _userName;
        private int _userId;
        private string? _usuarioSap;
        private string? _passwordSap;

        public string? UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public int UsuarioId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string? UsuarioSap
        {
            get { return _usuarioSap; }
            set { _usuarioSap = value; }
        }

        public string? PasswordSap
        {
            get { return _passwordSap; }
            set { _passwordSap = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(User);

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
