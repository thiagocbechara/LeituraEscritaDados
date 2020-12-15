using System;

namespace LeituraEscritaDados
{
    internal static class VariaveisDeAmbiente
    {
        public static string DelimitadorRegistros => "ç";

        private static string _environmentPath => Environment.GetEnvironmentVariable("homepath", EnvironmentVariableTarget.User);
        public static string CaminhoPastaLeitura => $"{_environmentPath}\\data\\in\\";
        public static string CaminhoPastaEscrita => $"{_environmentPath}\\data\\out\\";
    }
}
