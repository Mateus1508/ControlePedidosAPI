namespace Controle_de_pedidos.Helpers
{
    public static class IdentificadorHelper
    {
        private static int lastNumber = 0;
        private static char lastLetter = 'A';

        public static string GetNextPatternValue()
        {
            int nextNumber = GetNextSequentialNumber();
            char nextLetter = lastLetter;

            if (nextNumber > 999)
            {
                nextLetter = GetNextSequentialLetter();
                nextNumber = 1;
            }

            string patternValue = $"P_{nextLetter}{nextNumber:D3}_C";

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

