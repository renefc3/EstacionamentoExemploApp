namespace MeuEstacionamento.Dominio
{
    public abstract class BaseNegocio
    {
        public virtual int Id { get; set; }


        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return this.Id == obj.GetHashCode();
        }
    }
}