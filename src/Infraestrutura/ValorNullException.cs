namespace MeuEstacionamento.Infraestrutura
{
    public class ValorNullException : EstacionamentoException
    {
        public ValorNullException(string message)
            : base(message)
        {

        }
    }
}