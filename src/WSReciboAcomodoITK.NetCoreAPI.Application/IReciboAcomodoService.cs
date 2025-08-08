using WSReciboAcomodoITK.NetCoreAPI.Domain;

namespace WSReciboAcomodoITK.NetCoreAPI.Application
{
    public interface IReciboAcomodoService
    {

        bool SAP_ITK_REF_ObtieneDatosHu(HuEnvio huEnvio, out List<HuRespuesta> huRespuestas, out HuError huError);

        bool SAP_ITK_REF_GeneraOtEnMalEstado(OtMalEstadoEnvio otMalEstadoEnvio, out List<OtMalEstadoResult> otMalEstadoResults, out OtMalEstadoError otMalEstadoError);
    }
}
