using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuEstacionamento.Dominio
{
    public abstract class BaseNegocio
    {
        public int Id { get; set; }
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


        public Vaga Estacionar(Veiculo veiculo)
        {

        }


        public void Retirar(Veiculo veiculo)
        {

        }


        public void Retirar(Vaga vaga)
        {

        }

    }

}
