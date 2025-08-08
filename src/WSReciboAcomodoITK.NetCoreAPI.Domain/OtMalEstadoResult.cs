using System.Reflection;

namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class OtMalEstadoResult
    {
        private string? _hu;
        private string? _ot;
        private string? _confirmOt;
        private string? _movMcia;
        private string? _docMat;
        private string? _confirmMov;
        private string? _cambiarHu;

        public string? Hu
        {
            get { return _hu; }
            set { _hu = value; }
        }

        public string? Ot
        {
            get { return _ot; }
            set { _ot = value; }
        }

        public string? ConfirmOt
        {
            get { return _confirmOt; }
            set { _confirmOt = value; }
        }

        public string? MovMcia
        {
            get { return _movMcia; }
            set { _movMcia = value; }
        }

        public string? DocMat
        {
            get { return _docMat; }
            set { _docMat = value; }
        }

        public string? ConfirmMov
        {
            get { return _confirmMov; }
            set { _confirmMov = value; }
        }

        public string? CambiarHu
        {
            get { return _cambiarHu; }
            set { _cambiarHu = value; }
        }

        public string ObjectToXml()
        {
            var output = this;
            string objectAsXmlString;
            string className = string.Empty;
            var declaringType = MethodBase.GetCurrentMethod()?.DeclaringType;
            className = declaringType?.Name ?? nameof(OtMalEstadoResult);

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
