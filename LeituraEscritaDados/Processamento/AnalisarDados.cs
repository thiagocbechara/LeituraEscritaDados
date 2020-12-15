using LeituraEscritaDados.Modelos;
using System.Linq;

namespace LeituraEscritaDados.Processamento
{
    public class AnalisarDados
    {
        public static DadosAnalisados Executar(DadosExtraidos dadosExtraidos)
        {
            var analise = new DadosAnalisados
            {
                QuantidadeClientes = dadosExtraidos.Clientes.Count,
                QuantidadeVendedor = dadosExtraidos.Vendedores.Count
            };

            var performanceVendedores = dadosExtraidos.Vendas
                                        .GroupBy(x => x.NomeVendedor)
                                        .ToDictionary(
                                                x => x.Key,
                                                x => x.Sum(x => x.ItemVenda.Sum(x => x.Preco)))
                                        .OrderBy(x => x.Value)
                                        .ToDictionary(x => x.Key, x => x.Value);

            analise.NomePiorPendedor = performanceVendedores.LastOrDefault().Key;
            analise.IdVendaMaisCara = dadosExtraidos.Vendas.OrderBy(v => v.ItemVenda.Sum(i => i.Preco)).FirstOrDefault().Id;
            return analise;
        }
    }
}