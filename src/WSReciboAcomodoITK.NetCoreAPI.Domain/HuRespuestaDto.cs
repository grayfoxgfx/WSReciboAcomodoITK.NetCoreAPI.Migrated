namespace WSReciboAcomodoITK.NetCoreAPI.Domain
{
    public class HuRespuestaDto
    {
        public bool Success { get; set; }
        public List<HuRespuesta>? HuRespuestas { get; set; }
        public HuError? HuError { get; set; }
    }
}
