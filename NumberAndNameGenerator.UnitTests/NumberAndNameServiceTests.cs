using Newtonsoft.Json;

namespace NumberAndNameGenerator.UnitTests
{
    public class NumberAndNameServiceTests
    {
        private static readonly string TestDataFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestData");

        [Fact]
        public void Service_PrintsFullName_WhenDivisibleBy3and5()
        {
            // Arrange
            var iterations = 15;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith") };
            var expected = GetExpected("Service_PrintsFullName_WhenDivisibleBy3and5.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);

            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == iterations);
        }

        [Fact]
        public void Service_PrintsFirstName_WhenDivisibleBy3()
        {
            // Arrange
            var iterations = 3;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith") };
            var expected = GetExpected("Service_PrintsFirstName_WhenDivisibleBy3.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);

            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == iterations);
        }

        [Fact]
        public void Service_PrintsLastName_WhenDivisibleBy5()
        {
            // Arrange
            var iterations = 5;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith") };
            var expected = GetExpected("Service_PrintsLastName_WhenDivisibleBy5.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);

            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == 5);
        }

        [Fact]
        public void Service_PrintsMultipleFullName_WhenDivisibleBy3and5()
        {
            // Arrange
            var iterations = 15;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith"), new("Tara", "Kohler") };
            var expected = GetExpected("Service_PrintsMultipleFullName_WhenDivisibleBy3and5.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);

            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == iterations);
        }

        [Fact]
        public void Service_PrintsMultipleFirstName_WhenDivisibleBy3()
        {
            // Arrange
            var iterations = 3;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith"), new("Tara", "Kohler") };
            var expected = GetExpected("Service_PrintsMultipleFirstName_WhenDivisibleBy3.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);

            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == iterations);
        }

        [Fact]
        public void Service_PrintsMultipleLastName_WhenDivisibleBy5()
        {            // Arrange
            var iterations = 5;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith"), new("Tara", "Kohler") };
            var expected = GetExpected("Service_PrintsMultipleLastName_WhenDivisibleBy5.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);

            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == iterations);
        }

        [Fact]
        public void Service_PrintsJustNumber_WhenNotDivisibleBy3or5()
        {
            // Arrange
            var iterations = 2;
            var firstNameDivisor = 3;
            var lastNameDivisor = 5;
            var names = new List<Name> { new("Greg", "Goldsmith") };
            var expected = GetExpected("Service_PrintsJustNumber_WhenNotDivisibleBy3or5.txt");

            // Act
            var result = NumberAndNameService.Generate(iterations, firstNameDivisor, lastNameDivisor, names);
            
            // Assert
            Assert.Equal(expected, result);
            Assert.True(result.Count == iterations);
        }

        [Fact]
        public void Service_ThrowsArgumentException_WhenInvalidDivisorProvided()
        {
            // Arrange
            var invalidDivisor1 = 0;
            var invalidDivisor2 = -5;
            var names = new List<Name> { new("Greg", "Goldsmith") };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                NumberAndNameService.Generate(15, invalidDivisor1, invalidDivisor2, names));
        }

        [Fact]
        public void Service_ThrowsArgumentException_WhenEqualDivisorProvided()
        {
            // Arrange
            var invalidDivisor1 = 3;
            var invalidDivisor2 = 3;
            var names = new List<Name> { new("Greg", "Goldsmith") };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                NumberAndNameService.Generate(15, invalidDivisor1, invalidDivisor2, names));
        }

        [Fact]
        public void Service_ThrowsArgumentException_WhenEmptyNameListProvided()
        {
            // Arrange
            var invalidDivisor1 = 3;
            var invalidDivisor2 = 5;
            var names = new List<Name>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                NumberAndNameService.Generate(15, invalidDivisor1, invalidDivisor2, names));
        }

        private static List<string>? GetExpected(string fileName)
        {
            var filePath = Path.Combine(TestDataFolder, fileName);
            var fileContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<string>>(fileContent);
        }
    }
}