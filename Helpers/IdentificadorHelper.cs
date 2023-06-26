using Controle_de_pedidos.Models;

namespace Controle_de_pedidos.Helpers
{
    public static class IdentificadorHelper
    {
        private static int lastNumber = 0;
        private static char lastLetter = 'A';

        public static string GetNextPatternValue(List<PedidosModel> listaDados)
        {
            int nextNumber = GetNextSequentialNumber();
            char nextLetter = lastLetter;

            string patternValue = $"P_{nextLetter}{nextNumber:D3}_C";

            // Verificar se o identificador já existe na lista de dados
            while (listaDados.Any(d => d.Identificador == patternValue))
            {
                nextNumber = GetNextSequentialNumber();
                nextLetter = lastLetter;

                patternValue = $"P_{nextLetter}{nextNumber:D3}_C";
            }

            if (nextNumber > 999)
            {
                nextLetter = GetNextSequentialLetter();
                nextNumber = 1;
            }

            return patternValue;
        }

        private static int GetNextSequentialNumber()
        {
            lastNumber++;

            if (lastNumber > 999)
            {
                lastNumber = 1;
            }

            return lastNumber;
        }

        private static char GetNextSequentialLetter()
        {
            lastLetter++;

            if (lastLetter > 'Z')
            {
                lastLetter = 'A';
            }

            return lastLetter;
        }
    }
}
