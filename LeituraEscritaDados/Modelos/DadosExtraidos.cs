using System.Collections.Generic;

namespace LeituraEscritaDados.Modelos
{
    public class DadosExtraidos
    {
        public DadosExtraidos()
        {
            Vendedores = new List<Vendedor>();
            Clientes = new List<Cliente>();
            Vendas = new List<Venda>();
        }

        public List<Vendedor> Vendedores { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Venda> Vendas { get; set; }
    }
}
