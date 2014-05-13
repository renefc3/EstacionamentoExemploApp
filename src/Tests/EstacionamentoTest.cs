using System;
using MeuEstacionamento.Infraestrutura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeuEstacionamento.Dominio;
using Moq;

namespace Tests
{
    [TestClass]
    public class EstacionamentoTest
    {
        private Estacionamento estacionamento;

        [TestInitialize]
        public void inicializarEstacionamento()
        {
            estacionamento = new Estacionamento();
            
        }

        [TestMethod]
        [ExpectedException(typeof(ValorNullException))]
        public void Estacionamento_Estacionar_VeiculoNull_Lanca_ValorNullException()
        {
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            estacionamento.Estacionar(null, moqVaga.Object);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValorNullException))]
        public void Estacionamento_Estacionar_VagaNull_Lanca_ValorNullException()
        {
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            estacionamento.Estacionar(moqVeiculo.Object, null);
        }

        [TestMethod]
        [ExpectedException(typeof(EstacionarException))]
        public void Estacionamento_Estacionar_VeiculoJaEstacionado_Lanca_EstacionarException()
        {
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            Mock<VagaVeiculo> moqVagaVeiculo = new Mock<VagaVeiculo>();
            moqVeiculo.SetupProperty(x => x.Id, 1);
            moqVaga.SetupProperty(x => x.Id, 2);
            moqVagaVeiculo.SetupProperty(x => x.Veiculo, moqVeiculo.Object);
            estacionamento.Vagas.Add(moqVagaVeiculo.Object);


            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);
        }



        [TestMethod]
        [ExpectedException(typeof(EstacionarException))]
        public void Estacionamento_Estacionar_VagaJaUtilizada_Lanca_EstacionarException()
        {
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            Mock<VagaVeiculo> moqVagaVeiculo = new Mock<VagaVeiculo>();
            moqVeiculo.SetupProperty(x => x.Id, 1);
            moqVaga.SetupProperty(x => x.Id, 2);
            moqVagaVeiculo.SetupProperty(x => x.Vaga, moqVaga.Object);
            estacionamento.Vagas.Add(moqVagaVeiculo.Object);

            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);
        }
    }
}
