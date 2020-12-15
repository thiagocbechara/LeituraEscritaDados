using LeituraEscritaDados.Modelos;
using System.IO;

namespace LeituraEscritaDados.Processamento
{
    public class PersistirDados
    {
        public static void Executar(DadosAnalisados dadosAnalisados, string nomeCaminhoArquivo)
        {
            var conteudoArquivo = GerarConteudoAquivo(dadosAnalisados);
            File.WriteAllText(nomeCaminhoArquivo, conteudoArquivo);
        }

        private static string GerarConteudoAquivo(DadosAnalisados dados) =>
            string.Format("{1}{0}{2}{0}{3}{0}{4}",
                VariaveisDeAmbiente.DelimitadorRegistros,
                dados.QuantidadeClientes,
                dados.QuantidadeVendedor,
                dados.IdVendaMaisCara,
                dados.NomePiorPendedor);
    }
}