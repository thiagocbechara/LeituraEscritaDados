using System.Collections.Generic;

namespace LeituraEscritaDados.Modelos
{
    public class Venda
    {
        public string Id { get; set; }
        public string NomeVendedor { get; set; }
        public List<VendaItem> ItemVenda { get; set; }
    }
}