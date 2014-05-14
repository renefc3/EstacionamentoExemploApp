using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuEstacionamento.Infraestrutura;

namespace MeuEstacionamento.Dominio
{
    public class Veiculo : BaseNegocio
    {
        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }

        protected Veiculo()
        {
            
        }

        public Veiculo(string placa, string fabricante, string modelo, string ano)
        {
            Placa = placa;
            Fabricante = fabricante;
            Modelo = modelo;
            Ano = ano;
        }
    }


    public class Estacionamento : BaseNegocio
    {
        
        public ICollection<VagaVeiculo> VagasUtilizadas { get; set; }
        public ICollection<Vaga> Vagas { get; set; }

        public Estacionamento()
        {
            VagasUtilizadas = new Collection<VagaVeiculo>();
            Vagas = new Collection<Vaga>();
        }

        public void Estacionar(Veiculo veiculo, Vaga vaga)
        {
            if (veiculo == null)
                throw new ValorNullException("Selecione um veiculo para estacionar");

            if (vaga == null)
                throw new ValorNullException("Selecione a vaga que será estacionado o veiculo");

            if (!Vagas.Contains(vaga))
                throw new EstacionarException("Vaga selecionada não é do estacionado");

            var vagaAtual = VagasUtilizadas.ToList().FirstOrDefault(x => x.Vaga != null && x.Vaga.Id == vaga.Id);
            var vagaDoVeiculoAtual = VagasUtilizadas.ToList().FirstOrDefault(x => x.Veiculo!= null && x.Veiculo.Id == veiculo.Id);

            if (vagaDoVeiculoAtual != null)
                throw new EstacionarException("O veiculo já está estacionado.");

            if (vagaAtual != null)
                throw new EstacionarException("A vaga já possui um veiculo estacionado");

            this.VagasUtilizadas.Add(new VagaVeiculo(this, vaga,veiculo));
        }


        public void Retirar(Veiculo veiculo)
        {
            if (veiculo == null)
                throw new ValorNullException("Selecione um veiculo para retirar");
            
            var vagaDoVeiculoAtual = VagasUtilizadas.ToList().Where(x => x.Veiculo != null && x.Veiculo.Id == veiculo.Id).ToList();
            for (int i = 0; i < vagaDoVeiculoAtual.Count; i++)
                VagasUtilizadas.Remove(vagaDoVeiculoAtual[i]);
        }


        public void Retirar(Vaga vaga)
        {
            if (vaga == null)
                throw new ValorNullException("Selecione a vaga que será liberada");

            var vagaAtual = VagasUtilizadas.ToList().Where(x => x.Vaga != null && x.Vaga.Id == vaga.Id).ToList();
            for (int i = 0; i < vagaAtual.Count; i++)
                VagasUtilizadas.Remove(vagaAtual[i]);
        }

    }

    public class VagaVeiculo : BaseNegocio
    {
        public Estacionamento Estacionamento { get; set; }
        public virtual Vaga Vaga { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        protected VagaVeiculo()
        {

        }
        public VagaVeiculo(Estacionamento estacionamento, Vaga vaga, Veiculo veiculo)
        {
            Estacionamento = estacionamento;
            Vaga = vaga;
            Veiculo = veiculo;
            DataEntrada = DateTime.Now;
        }
    }
}
