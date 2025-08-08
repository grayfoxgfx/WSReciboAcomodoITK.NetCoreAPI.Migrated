
using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WSReciboAcomodoITK.NetCoreAPI.API.Controllers;
using WSReciboAcomodoITK.NetCoreAPI.Application;
using WSReciboAcomodoITK.NetCoreAPI.Domain;
using System.Collections.Generic;

namespace WSReciboAcomodoITK.NetCoreAPI.Tests
{
    public class ReciboAcomodoControllerTests
    {
        private Mock<IReciboAcomodoService> _serviceMock;
        private ReciboAcomodoController _controller;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IReciboAcomodoService>();
            _controller = new ReciboAcomodoController(_serviceMock.Object);
        }

        [Test]
        public void SAP_ITK_REF_ObtieneDatosHu_ReturnsExpectedResult()
        {
            var huEnvio = new HuEnvio { Hu = "12345", Material = "MAT1", Oc = "OC1" };
            var huRespuestas = new List<HuRespuesta> { new HuRespuesta { Hu = "12345", Material = "MAT1" } };
            var huError = new HuError { };
            _serviceMock.Setup(s => s.SAP_ITK_REF_ObtieneDatosHu(huEnvio, out huRespuestas, out huError)).Returns(true);

            var result = _controller.SAP_ITK_REF_ObtieneDatosHu(huEnvio);
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.Not.Null);
            var value = okResult.Value;
            var type = value.GetType();
            var successProp = type.GetProperty("Success");
            var huRespuestasProp = type.GetProperty("HuRespuestas");
            var huErrorProp = type.GetProperty("HuError");
            Assert.That(successProp, Is.Not.Null);
            Assert.That(huRespuestasProp, Is.Not.Null);
            Assert.That(huErrorProp, Is.Not.Null);
            var success = (bool?)successProp.GetValue(value);
            var huRespuestasResult = huRespuestasProp.GetValue(value);
            var huErrorResult = huErrorProp.GetValue(value);
            Assert.That(success, Is.True);
            Assert.That(huRespuestasResult, Is.EqualTo(huRespuestas));
            Assert.That(huErrorResult, Is.EqualTo(huError));
        }

        [Test]
        public void SAP_ITK_REF_GeneraOtEnMalEstado_ReturnsExpectedResult()
        {
            var otMalEstadoEnvio = new OtMalEstadoEnvio { Hu = "12345", Cantidad = "10", MalEdo = "E1", MotivoRech = "Test" };
            var otMalEstadoResults = new List<OtMalEstadoResult> { new OtMalEstadoResult { Hu = "12345", Ot = "OT1" } };
            var otMalEstadoError = new OtMalEstadoError { Hu = "12345", Error = "E", DescripError = "ErrorDesc" };
            _serviceMock.Setup(s => s.SAP_ITK_REF_GeneraOtEnMalEstado(otMalEstadoEnvio, out otMalEstadoResults, out otMalEstadoError)).Returns(true);

            var result = _controller.SAP_ITK_REF_GeneraOtEnMalEstado(otMalEstadoEnvio);
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.Not.Null);
            var value = okResult.Value;
            var type = value.GetType();
            var successProp = type.GetProperty("Success");
            var resultsProp = type.GetProperty("OtMalEstadoResults");
            var errorProp = type.GetProperty("OtMalEstadoError");
            Assert.That(successProp, Is.Not.Null);
            Assert.That(resultsProp, Is.Not.Null);
            Assert.That(errorProp, Is.Not.Null);
            var success = (bool?)successProp.GetValue(value);
            var results = resultsProp.GetValue(value);
            var error = errorProp.GetValue(value);
            Assert.That(success, Is.True);
            Assert.That(results, Is.EqualTo(otMalEstadoResults));
            Assert.That(error, Is.EqualTo(otMalEstadoError));
        }
    }
}
