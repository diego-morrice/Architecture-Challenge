using System;

namespace MidiaSocial.Utilidades
{
    public class Guardiao
    {
        public static void ValidarId(string nomePropriedade, Guid id)
        {
            ValidarId(id, nomePropriedade + " id inválido!");
        }

        public static void ValidarId(Guid id, string mensagemDeErro)
        {
            if (id == Guid.Empty)
                throw new Exception(mensagemDeErro);
        }

        public static void ValidarId(string nomePropriedade, int id)
        {
            ValidarId(id, nomePropriedade + " id inválido!");
        }

        public static void ValidarId(int id, string mensagemDeErro)
        {
            if (!(id > 0))
                throw new Exception(mensagemDeErro);
        }

        public static void ValidarNumeroNaoNegativo(int numero, string nomePropriedade)
        {
            if (numero < 0)
                throw new Exception(nomePropriedade + " não pode ser negativo!");
        }

        public static void ValidarNullOuVazioMensagemPadrao(string valor, string nomePropriedade)
        {
            if (String.IsNullOrEmpty(valor))
                throw new Exception(nomePropriedade + " é obrigatório!");
        }

        public static void ValidarNullOuVazio(string valor, string mensagemDeErro)
        {
            if (String.IsNullOrEmpty(valor))
                throw new Exception(mensagemDeErro);
        }

        public static void ValidarTamanhoString(string nomePropriedade, string stringValor, int maximo)
        {
            ValidarTamanhoString(stringValor, maximo, nomePropriedade + " não pode ter mais que " + maximo + " caracteres");
        }

        public static void ValidarTamanhoString(string stringvalor, int maximo, string mensagem)
        {
            int length = stringvalor.Length;
            if (length > maximo)
            {
                throw new Exception(mensagem);
            }
        }
        public static void ValidarTamanhoString(string nomePropriedade, string stringvalor, int minimo, int maximo)
        {
            ValidarTamanhoString(stringvalor, minimo, maximo, nomePropriedade + " deve ter de " + minimo + " à " + maximo + " caracteres!");
        }

        public static void ValidarTamanhoString(string stringValor, int minimo, int maximo, string mensagem)
        {
            if (String.IsNullOrEmpty(stringValor))
                stringValor = String.Empty;

            int length = stringValor.Length;
            if (length < minimo || length > maximo)
            {
                throw new Exception(mensagem);
            }
        }

        public static void ValidarIguais(string a, string b, string mensagemDeErro)
        {
            if (a != b)
                throw new Exception(mensagemDeErro);
        }
    }
}
