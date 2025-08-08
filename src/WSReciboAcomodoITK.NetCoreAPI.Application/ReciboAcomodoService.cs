using WSReciboAcomodoITK.NetCoreAPI.Domain;
using WSReciboAcomodoITK.NetCoreAPI.Persistence;
using WSReciboAcomodoITK.NetCoreAPI.Infrastructure;

namespace WSReciboAcomodoITK.NetCoreAPI.Application
{
    public class ReciboAcomodoService : IReciboAcomodoService
    {

        /// <summary>
        /// Retrieves HU data from SAP ITK REF, migrated from WCF logic.
        /// </summary>
        public bool SAP_ITK_REF_ObtieneDatosHu(HuEnvio huEnvio, out List<HuRespuesta> huRespuestas, out HuError huError)
        {
            bool result = false;
            huRespuestas = new List<HuRespuesta>();
            huError = new HuError();
            try
            {
                if (huEnvio != null)
                {
                    // Call DataAccess layer (assume DataAccess is available in .NET)
                    result = new DataAccess().SAP_ITK_REF_ObtieneDatosHu(huEnvio, out huRespuestas, out huError);
                }
                else
                {
                    huError.Error = "Inicialice los parametros de entrada";
                    huError.IsError = true;
                }
            }
            catch (Exception ex)
            {
                huError.Error = ex.Message;
                huError.IsError = true;
                // Logging as in legacy code
                Logs.InsertarLogOperaciones(ex.Message, 3, huEnvio?.ObjectToXml() ?? string.Empty, huError.ObjectToXml() ?? string.Empty);
            }
            return result;
        }

        public bool SAP_ITK_REF_GeneraOtEnMalEstado(OtMalEstadoEnvio otMalEstadoEnvio, out List<OtMalEstadoResult> otMalEstadoResults, out OtMalEstadoError otMalEstadoError)
        {
            otMalEstadoResults = new List<OtMalEstadoResult>();
            otMalEstadoError = new OtMalEstadoError();
            return true;
        }
    }
}
