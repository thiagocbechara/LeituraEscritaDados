using LeituraEscritaDados.Enums;
using LeituraEscritaDados.Factories;
using LeituraEscritaDados.Modelos;
using System;
using System.IO;

namespace LeituraEscritaDados.Processamento
{
    internal class ExtrairDados
    {
        internal static DadosExtraidos Executar(string nomeCaminhoArquivo)
        {
            var conteudoArquivo = File.ReadAllText(nomeCaminhoArquivo).Split(Environment.NewLine);
            var registro = new DadosExtraidos();
            foreach (var linhaArquivo in conteudoArquivo)
            {
                var registrosLinha = linhaArquivo.Split(VariaveisDeAmbiente.DelimitadorRegistros);
                switch (registrosLinha[0])
                {
                    case TipoRegistroEnum.DadosVendedor:
                        var factoryVendedor = new VendedorFactory(registrosLinha);
                        registro.Vendedores.Add(factoryVendedor.FactoryMethod());
                        break;
                    case TipoRegistroEnum.DadosCliente:
                        var factoryCliente = new ClienteFactory(registrosLinha);
                        registro.Clientes.Add(factoryCliente.FactoryMethod());
                        break;
                    case TipoRegistroEnum.DadosVenda:
                        var factoryVenda = new VendaFactory(registrosLinha);
                        registro.Vendas.Add(factoryVenda.FactoryMethod());
                        break;
                }
            }

            return registro;
        }
    }
}