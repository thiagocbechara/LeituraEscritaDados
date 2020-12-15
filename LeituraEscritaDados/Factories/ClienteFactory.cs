using LeituraEscritaDados.Modelos;

namespace LeituraEscritaDados.Factories
{
    public class ClienteFactory : Factory<Cliente>
    {
        public ClienteFactory(string[] registro) : base(registro)
        {
        }

        public override Cliente FactoryMethod()
        {
            var cliente = new Cliente
            {
                CNPJ = Registro.Length >= 2 ? Registro[1] : string.Empty,
                Nome = Registro.Length >= 3 ? Registro[2] : string.Empty,
                AreaNegocio = Registro.Length >= 4 ? Registro[3] : string.Empty
            };
            return cliente;
        }
    }
}
