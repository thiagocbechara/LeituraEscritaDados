using LeituraEscritaDados.Processamento;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LeituraEscritaDados
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lógica para simular um serviço
            var processo = new Processar();
            var taskProcesso = Task.Run(() => processo.Executar());
            var taskControle = Task.Run(() => {
                if (Console.ReadLine() == "PARAR")
                {
                    processo.SolicitarEncerramento();
                    Console.Write("Aguardando encerramento do processo");
                    while (taskProcesso.Status != TaskStatus.RanToCompletion)
                    {
                        Console.Write(".");
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
            });
            Console.WriteLine("Processo em execução.");
            Console.WriteLine("Para encerrar o processo, digite PARAR e tecle ENTER.");

            while(taskProcesso.Status != TaskStatus.RanToCompletion || taskControle.Status != TaskStatus.RanToCompletion)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            Console.WriteLine();
            Console.WriteLine("Processo encerrado");
            Console.ReadLine();
        }
    }
}
