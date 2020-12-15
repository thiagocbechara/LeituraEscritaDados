using LeituraEscritaDados.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace LeituraEscritaDados.Factories
{
    public class VendaFactory : Factory<Venda>
    {
        public VendaFactory(string[] registro) : base(registro)
        {
        }

        public override Venda FactoryMethod()
        {
            var venda = new Venda
            {
                Id = Registro.Length >= 2 ? Registro[1] : string.Empty,
                ItemVenda = CriarItensVenda(),
                NomeVendedor = Registro.Length >= 4 ? Registro[3] : string.Empty
            };
            return venda;
        }

        private List<VendaItem> CriarItensVenda()
        {
            var itens = new List<VendaItem>();
            if (Registro.Length >= 3)
            {
                var registrosItems = Registro[2].Replace("[", "").Replace("]", "").Split(',');
                itens.AddRange(registrosItems.Select(CriarItemVenda));
            }
            return itens;
        }

        private static VendaItem CriarItemVenda(string registro)
        {
            var registroArray = registro.Split('-');
            var item = new VendaItem
            {
                ItemId = registroArray.Length >= 1 ? registroArray[0] : string.Empty,
                Quantidade = registroArray.Length >= 2 && decimal.TryParse(registroArray[1], out decimal quantidade) ? quantidade : 0,
                Preco = registroArray.Length >= 3 && decimal.TryParse(registroArray[1], out decimal preco) ? preco : 0
            };
            return item;
        }
    }
}
