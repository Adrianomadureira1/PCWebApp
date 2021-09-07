using System;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PCWebApp.Repository.Entity;
using PCWebApp.Repository.Interfaces;
using PCWebApp.Services;
using PCWebApp.Services.Profiles;

namespace PCWebApp.Tests
{
    [TestFixture]
    public class ColaboradorServiceTests
    {
        Mock<IColaboradorRepository<Colaborador>> mockColaboradorRepository;
        Mock<IMapper> mockAutomapper;

        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ModelProfile>());
            config.AssertConfigurationIsValid();
        }

        [Test]
        public void ObterListaDeColaboradores(){
            mockAutomapper = new Mock<IMapper>();
            mockAutomapper.Setup(m => m.Map<List<ColaboradorDTO>>(It.IsAny<List<Colaborador>>())).Returns(new List<ColaboradorDTO>());
            mockAutomapper.Setup(m => m.Map<List<Colaborador>>(It.IsAny<List<ColaboradorDTO>>())).Returns(new List<Colaborador>());

            mockColaboradorRepository = new Mock<IColaboradorRepository<Colaborador>>();
            mockColaboradorRepository.Setup(r => r.Ler()).Returns(new List<Colaborador>(){ new Colaborador() });

            var service = new ColaboradorService(mockAutomapper.Object, mockColaboradorRepository.Object);

            var resultado = service.Ler();

            Assert.That(resultado, Is.EqualTo(new List<ColaboradorDTO>()));
        }

        [Test]
        public void ObterColaborador(){
            mockAutomapper = new Mock<IMapper>();
            mockAutomapper.Setup(m => m.Map<ColaboradorDTO>(It.IsAny<Colaborador>())).Returns(new ColaboradorDTO());
            mockAutomapper.Setup(m => m.Map<Colaborador>(It.IsAny<ColaboradorDTO>())).Returns(new Colaborador());

            mockColaboradorRepository = new Mock<IColaboradorRepository<Colaborador>>();
            mockColaboradorRepository.Setup(r => r.Ler(It.IsAny<Guid>())).Returns(new Colaborador());

            var service = new ColaboradorService(mockAutomapper.Object, mockColaboradorRepository.Object);

            var resultadoEsperado = new ColaboradorDTO();

            var resultado = service.Ler(resultadoEsperado.ID);

            Assert.NotNull(resultado);
            Assert.That(resultado.ID, Is.EqualTo(resultadoEsperado.ID));
        }
    }
}