namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class OtMalEstadoRespuestaDto
    {
        public bool Success { get; set; }
        public List<OtMalEstadoResult>? OtMalEstadoResults { get; set; }
        public OtMalEstadoError? OtMalEstadoError { get; set; }
    }
}
