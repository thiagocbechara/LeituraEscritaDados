using System.IO;

namespace LeituraEscritaDados.Processamento
{
    public class Processar
    {
        public bool FinalizarProcesso { get; private set; }

        public void Executar()
        {
            if (!Directory.Exists(VariaveisDeAmbiente.CaminhoPastaLeitura)) { return; }
            while (!FinalizarProcesso)
            {
                var arquivos = Directory.GetFiles(VariaveisDeAmbiente.CaminhoPastaLeitura, "*.dat");
                foreach (var arquivo in arquivos)
                {
                    try
                    {
                        var dados = ExtrairDados.Executar(arquivo);
                        if(FinalizarProcesso) { return; }
                        var analise = AnalisarDados.Executar(dados);
                        if(FinalizarProcesso) { return; }
                        PersistirDados.Executar(analise, $"{VariaveisDeAmbiente.CaminhoPastaEscrita}{ExtrairNomeArquivoOrigem(arquivo)}.done.dat");
                        if(FinalizarProcesso) { return; }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
        }

        private string ExtrairNomeArquivoOrigem(string arquivoCaminho) =>
            arquivoCaminho.Replace(VariaveisDeAmbiente.CaminhoPastaLeitura, "").Split('.')[0];

        /// <summary>
        /// Indica ao serviço a ordem de finalizar o processamento
        /// </summary>
        public void SolicitarEncerramento() =>
            FinalizarProcesso = true;
    }
}
