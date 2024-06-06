namespace GestaoInvestimentosCore.Entities
{
    public class AssertionValidations
    {
        public AssertionValidations()
        {
            
        }

        public static void AssertArgumentNullOrEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLenght(string stringValue, int max, string message)
        {
            int lenght = stringValue.Trim().Length;
            if (lenght > max)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentLenght(string stringValue, int min, int max, string message)
        {
            int lenght = stringValue.Trim().Length;
            if (lenght > max || lenght < min)
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentExactLenght(string stringValue, int lenghtString, string message)
        {
            int lenght = stringValue.Trim().Length;
            if (lenght != lenghtString)
            {
                throw new DomainException(message);
            }
        }
    }
}
