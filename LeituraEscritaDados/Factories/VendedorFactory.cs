using LeituraEscritaDados.Modelos;

namespace LeituraEscritaDados.Factories
{
    public class VendedorFactory : Factory<Vendedor>
    {
        public VendedorFactory(string[] registro) : base(registro)
        {
        }

        public override Vendedor FactoryMethod()
        {
            var vendedor = new Vendedor
            {
                CPF = Registro.Length >= 2 ? Registro[1] : string.Empty,
                Nome = Registro.Length >= 3 ? Registro[2] : string.Empty,
                Salario = Registro.Length >= 4 && decimal.TryParse(Registro[3], out decimal salario) ? salario : 0
            };
            return vendedor;
        }
    }
}
