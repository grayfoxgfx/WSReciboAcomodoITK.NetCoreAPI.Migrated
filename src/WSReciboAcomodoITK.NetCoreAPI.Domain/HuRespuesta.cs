using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class HuRespuesta
    {
        private string? _hu;
        private string? _material;
        private string? _cantidad;
        private string? _calidad;
        private string? _pasillo;

        public string? Hu
        {
            get { return _hu; }
            set { _hu = value; }
        }

        public string? Material
        {
            get { return _material; }
            set { _material = value; }
        }

        public string? Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public string? Calidad
        {
            get { return _calidad; }
            set { _calidad = value; }
        }

        public string? Pasillo
        {
            get { return _pasillo; }
            set { _pasillo = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(HuRespuesta);

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
