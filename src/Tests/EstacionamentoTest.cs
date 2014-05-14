using System;
using System.Linq;
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

        #region Estacionar


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
        public void Estacionamento_Estacionar_VagaNaoExisteNoEstacionamento_Lanca_EstacionarException()
        {
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            Mock<VagaVeiculo> moqVagaVeiculo = new Mock<VagaVeiculo>();
            moqVeiculo.SetupProperty(x => x.Id, 1);
            moqVaga.SetupProperty(x => x.Id, 2);
            moqVagaVeiculo.SetupProperty(x => x.Veiculo, moqVeiculo.Object);
            estacionamento.VagasUtilizadas.Add(moqVagaVeiculo.Object);


            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(EstacionarException))]
        public void Estacionamento_Estacionar_VeiculoJaSEstacionado_Lanca_EstacionarException()
        {
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            Mock<VagaVeiculo> moqVagaVeiculo = new Mock<VagaVeiculo>();
            moqVeiculo.SetupProperty(x => x.Id, 1);
            moqVaga.SetupProperty(x => x.Id, 2);
            moqVaga.CallBase = true;

            moqVagaVeiculo.SetupProperty(x => x.Veiculo, moqVeiculo.Object);
            estacionamento.Vagas.Add(moqVaga.Object);
            estacionamento.VagasUtilizadas.Add(moqVagaVeiculo.Object);


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
            moqVaga.CallBase = true;

            moqVagaVeiculo.SetupProperty(x => x.Vaga, moqVaga.Object);
            estacionamento.Vagas.Add(moqVaga.Object);

            estacionamento.VagasUtilizadas.Add(moqVagaVeiculo.Object);

            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);
        }


        [TestMethod]
        public void Estacionamento_Estacionar_DeveConterVagaVeiculoNaLista()
        {
            int idVeiculo = 2;
            int idVaga = 3;
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            moqVaga.CallBase = true;
            moqVeiculo.SetupProperty(x => x.Id, idVeiculo);
            moqVaga.SetupProperty(x => x.Id, idVaga);
            estacionamento.Vagas.Add(moqVaga.Object);

            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);


            CollectionAssert.Contains(estacionamento.VagasUtilizadas.Select(c => c.Vaga.Id).ToList(), idVaga);
            CollectionAssert.Contains(estacionamento.VagasUtilizadas.Select(c => c.Veiculo.Id).ToList(), idVeiculo);
        }

        #endregion

        #region Retirar

        [TestMethod]
        [ExpectedException(typeof(ValorNullException))]
        public void Estacionamento_Retirar_VeiculoNull_Lanca_ValorNullException()
        {
            Veiculo veiculo = null;

            estacionamento.Retirar(veiculo);
        }

        [TestMethod]
        public void Estacionamento_Retirar_Veiculo_NaoDeveConterVagaVeiculoNaLista()
        {
            int idVeiculo = 2;
            int idVaga = 3;
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            moqVaga.CallBase = true;
            moqVeiculo.SetupProperty(x => x.Id, idVeiculo);
            moqVaga.SetupProperty(x => x.Id, idVaga);
            estacionamento.Vagas.Add(moqVaga.Object);
            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);

            estacionamento.Retirar(moqVeiculo.Object);


            CollectionAssert.DoesNotContain(estacionamento.VagasUtilizadas.Select(c => c.Vaga.Id).ToList(), idVaga);
            CollectionAssert.DoesNotContain(estacionamento.VagasUtilizadas.Select(c => c.Veiculo.Id).ToList(), idVeiculo);
        }




        [TestMethod]
        [ExpectedException(typeof(ValorNullException))]
        public void Estacionamento_Retirar_VagaNull_Lanca_ValorNullException()
        {
            Vaga vaga = null;

            estacionamento.Retirar(vaga);
        }



        [TestMethod]
        public void Estacionamento_Retirar_Vaga_NaoDeveConterVagaVeiculoNaLista()
        {
            int idVeiculo = 2;
            int idVaga = 3;
            Mock<Veiculo> moqVeiculo = new Mock<Veiculo>();
            Mock<Vaga> moqVaga = new Mock<Vaga>();
            moqVaga.CallBase = true;
            moqVeiculo.SetupProperty(x => x.Id, idVeiculo);
            moqVaga.SetupProperty(x => x.Id, idVaga);
            estacionamento.Vagas.Add(moqVaga.Object);
            estacionamento.Estacionar(moqVeiculo.Object, moqVaga.Object);

            estacionamento.Retirar(moqVaga.Object);


            CollectionAssert.DoesNotContain(estacionamento.VagasUtilizadas.Select(c => c.Vaga.Id).ToList(), idVaga);
            CollectionAssert.DoesNotContain(estacionamento.VagasUtilizadas.Select(c => c.Veiculo.Id).ToList(), idVeiculo);
        }

        #endregion


    }
}
