using System.Xml.Linq;

namespace NumberAndNameGenerator
{
    /// <summary>
    /// This class is responsible for generating a sequence of numbers and names based on specified divisors.
    /// </summary>
    public class NumberAndNameService
    {
        /// <summary>
        ///This method prints numbers and names from 1 to a specified number. Each iteration will recieve it's own line represented by an element in the resulting List. For numbers divisible by the firstNameDivisor parameter, it prints "[FirstName]" instead of the number, and for numbers divisible by the lastNameDivisor parameter, it prints "[LastName]" instead of the number. For numbers that are divisible by both the firstNameDivisor and the lastNameDivisor, it prints "[FirstName LastName]". Finally, a list of names is passed in that indicates the names to print based on the divisors.
        /// </summary>
        /// <param name="iterations">The number of iterations for the method to execute. The maximum number of iterations is int.MaxValue - 1 (2,147,483,646).</param>
        /// <param name="firstNameDivisor">The divisor for printing the first name.</param>
        /// <param name="lastNameDivisor">The divisor for printing the last name.</param>
        /// <param name="namesToPrint">The list of names to print.</param>
        /// <returns>A list of strings that represent new line.</returns>
        /// <exception cref="ArgumentException">An exception will be thrown if the iterations, firstNameDivisor, or lastNameDivisor parameters are less than or equal to 0. These parameters must all be greater than 0.</exception>
        /// <exception cref="ArgumentException">An exception will be thrown if the namesToPrint parameter is null or empty. You must supply at least one name to print.</exception>
        /// <exception cref="ArgumentException">An exception will be thrown if the firstNameDivisor and lastNameDivisor are equal to each other. These values must be different.</exception>
        /// <exception cref="ArgumentException"></exception>
        public static List<string> Generate(int iterations, int firstNameDivisor, int lastNameDivisor, List<Name> namesToPrint)
        {
            if (iterations <= 0 || firstNameDivisor <= 0 || lastNameDivisor <= 0)
            {
                throw new ArgumentException("The parameters for iterations, firstNameDivisor, and lastNameDivisor must be greater than 0.");
            }

            if (namesToPrint == null || namesToPrint.Count == 0)
            {
                throw new ArgumentException("The parameter namesToPrint cannot be null or empty.");
            }

            if (firstNameDivisor == lastNameDivisor)
            {
                throw new ArgumentException("The parameters firstNameDivisor and lastNameDivisor cannot be equal.");
            }

            if (iterations == int.MaxValue)
            {
                iterations = int.MaxValue - 1; // Prevent overflow for the last increment of i inside the for loop execution.
            }

            List<string> result = [];

            for (int i = 1; i <= iterations; i++)
            {
                string? line;

                if (i % firstNameDivisor == 0 && i % lastNameDivisor == 0)
                {
                    line = GetLineValue(namesToPrint, LineType.FullName);
                }
                else if (i % firstNameDivisor == 0)
                {
                    line = GetLineValue(namesToPrint, LineType.FirstName);
                }
                else if (i % lastNameDivisor == 0)
                {
                    line = GetLineValue(namesToPrint, LineType.LastName);
                }
                else
                {
                    line = i.ToString();
                }

                result.Add(line);
            }

            return result;
        }

        private static string GetLineValue(List<Name> namesToPrint, LineType lineType)
        {
            string line = string.Empty;

            for (int i = 0; i < namesToPrint.Count; i++)
            {
                var name = namesToPrint[i];

                switch (lineType)
                {
                    case LineType.FirstName:
                        line += $"{name.FirstName}";
                        break;
                    case LineType.LastName:
                        line += $"{name.LastName}";
                        break;
                    case LineType.FullName:
                        line += $"{name.FirstName} {name.LastName}";
                        break;
                    default:
                        break;
                }
                
                if (i < namesToPrint.Count - 1) // Check if it's not the last item
                {
                    line += ", ";
                }
            }

            return line;
        }
    }
}
