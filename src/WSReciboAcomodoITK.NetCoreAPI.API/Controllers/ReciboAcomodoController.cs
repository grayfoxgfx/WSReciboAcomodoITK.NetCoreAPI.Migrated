using Microsoft.AspNetCore.Mvc;
using WSReciboAcomodoITK.NetCoreAPI.Application;
using WSReciboAcomodoITK.NetCoreAPI.Domain;

namespace WSReciboAcomodoITK.NetCoreAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// API Controller for ReciboAcomodo operations. Provides endpoints for HU data retrieval and OT generation in bad state.
    /// </summary>
    public class ReciboAcomodoController : ControllerBase
    {
        /// <summary>
        /// Service dependency for business logic operations.
        /// </summary>
        private readonly IReciboAcomodoService _service;

        /// <summary>
        /// Constructor for ReciboAcomodoController.
        /// </summary>
        /// <param name="service">Injected business logic service.</param>
        public ReciboAcomodoController(IReciboAcomodoService service)
        {
            _service = service;
        }


        /// <summary>
        /// Retrieves HU data from SAP ITK REF.
        /// </summary>
        /// <param name="request">HU request payload.</param>
        /// <returns>HU response DTO containing success flag, HU responses, and error details.</returns>
        [HttpPost("SAP_ITK_REF_ObtieneDatosHu")]
        public ActionResult<HuRespuestaDto> SAP_ITK_REF_ObtieneDatosHu([FromBody] HuEnvio request)
        {
            // Prepare output variables for service call
            List<HuRespuesta> huRespuestas;
            HuError huError;
            // Call business logic service
            var result = _service.SAP_ITK_REF_ObtieneDatosHu(request, out huRespuestas, out huError);
            // Build response DTO
            var response = new HuRespuestaDto
            {
                Success = result,
                HuRespuestas = huRespuestas,
                HuError = huError
            };
            return Ok(response);
        }

        /// <summary>
        /// Generates OT in bad state from SAP ITK REF.
        /// </summary>
        /// <param name="request">OT bad state request payload.</param>
        /// <returns>OT bad state response DTO containing success flag, results, and error details.</returns>
        [HttpPost("SAP_ITK_REF_GeneraOtEnMalEstado")]
        public ActionResult<OtMalEstadoRespuestaDto> SAP_ITK_REF_GeneraOtEnMalEstado([FromBody] OtMalEstadoEnvio request)
        {
            // Prepare output variables for service call
            List<OtMalEstadoResult> otMalEstadoResults;
            OtMalEstadoError otMalEstadoError;
            // Call business logic service
            var result = _service.SAP_ITK_REF_GeneraOtEnMalEstado(request, out otMalEstadoResults, out otMalEstadoError);
            // Build response DTO
            var response = new OtMalEstadoRespuestaDto
            {
                Success = result,
                OtMalEstadoResults = otMalEstadoResults,
                OtMalEstadoError = otMalEstadoError
            };
            return Ok(response);
        }
    }
}
