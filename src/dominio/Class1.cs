using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuEstacionamento.Infraestrutura;

namespace MeuEstacionamento.Dominio
{
    public abstract class BaseNegocio
    {
        public virtual int Id { get; set; }
    }

    public class Veiculo : BaseNegocio
    {
        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }


    }


    public class Estacionamento : BaseNegocio
    {
        public int QtdVaga { get; set; }

        public ICollection<VagaVeiculo> Vagas { get; set; }

        public Estacionamento()
        {
            Vagas = new Collection<VagaVeiculo>();
        }

        public void Estacionar(Veiculo veiculo, Vaga vaga)
        {
            if (veiculo == null)
                throw new ValorNullException("Selecione um veiculo para estacionar");

            if (vaga == null)
                throw new ValorNullException("Selecione a vaga que será estacionado o veiculo");

            var vagaAtual = Vagas.ToList().FirstOrDefault(x => x.Vaga.Id == vaga.Id);
            var vagaDoVeiculoAtual = Vagas.ToList().FirstOrDefault(x => x.Veiculo.Id == veiculo.Id);

            if (vagaDoVeiculoAtual != null)
                throw new EstacionarException("O veiculo já está estacionado.");

            if (vagaAtual != null)
                throw new EstacionarException("A vaga já possui um veiculo estacionado");


        }


        public void Retirar(Veiculo veiculo)
        {

        }


        public void Retirar(Vaga vaga)
        {

        }

    }

    public class VagaVeiculo : BaseNegocio
    {
        public Estacionamento Estacionamento { get; set; }
        public virtual Vaga Vaga { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        public VagaVeiculo(Estacionamento estacionamento, Vaga vaga, Veiculo veiculo)
        {
            Estacionamento = estacionamento;
            Vaga = vaga;
            Veiculo = veiculo;
            DataEntrada = DateTime.Now;
        }
    }
}
