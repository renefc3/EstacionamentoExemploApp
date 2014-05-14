namespace MeuEstacionamento.Infraestrutura
{
    public class EstacionarException : EstacionamentoException
    {
        public EstacionarException(string message)
            : base(message)
        {

        }
    }
}