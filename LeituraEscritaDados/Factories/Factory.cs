namespace LeituraEscritaDados.Factories
{
    public abstract class Factory<T>
    {
        protected string[] Registro { get; set; }

        public Factory(string[] registro)
        {
            Registro = registro;
        }

        public abstract T FactoryMethod();
    }
}