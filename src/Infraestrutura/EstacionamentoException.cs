using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuEstacionamento.Infraestrutura
{
    public class EstacionamentoException : Exception
    {
        public EstacionamentoException(string message)
            : base(message)
        {

        }
    }
}
