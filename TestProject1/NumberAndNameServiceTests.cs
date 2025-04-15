using Newtonsoft.Json;

namespace NumberAndNameGenerator.UnitTests
{
    public class NumberAndNameServiceTests
    {
        private static readonly string TestDataFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestData");

        [Fact]
        public void Service_PrintsFullName_WhenDivisibleBy3and5()
        {
            var result = NumberAndNameService.GetLines(15, 3, 5, [new("Greg", "Goldsmith")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsFullName_WhenDivisibleBy3and5.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 15);
        }

        [Fact]
        public void Service_PrintsFirstName_WhenDivisibleBy3()
        {
            var result = NumberAndNameService.GetLines(3, 3, 5, [new("Greg", "Goldsmith")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsFirstName_WhenDivisibleBy3.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void Service_PrintsLastName_WhenDivisibleBy5()
        {
            var result = NumberAndNameService.GetLines(5, 3, 5, [new("Greg", "Goldsmith")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsLastName_WhenDivisibleBy5.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 5);
        }

        [Fact]
        public void Service_PrintsMultipleFullName_WhenDivisibleBy3and5()
        {
            var result = NumberAndNameService.GetLines(15, 3, 5, [new("Greg", "Goldsmith"), new("Tara", "Kohler")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsMultipleFullName_WhenDivisibleBy3and5.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 15);
        }

        [Fact]
        public void Service_PrintsMultipleFirstName_WhenDivisibleBy3()
        {
            var result = NumberAndNameService.GetLines(3, 3, 5, [new("Greg", "Goldsmith"), new("Tara", "Kohler")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsMultipleFirstName_WhenDivisibleBy3.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void Service_PrintsMultipleLastName_WhenDivisibleBy5()
        {
            var result = NumberAndNameService.GetLines(5, 3, 5, [new("Greg", "Goldsmith"), new("Tara", "Kohler")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsMultipleLastName_WhenDivisibleBy5.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 5);
        }

        [Fact]
        public void Service_PrintsJustNumber_WhenNotDivisibleBy3or5()
        {
            var nameService = new NumberAndNameService();
            var result = NumberAndNameService.GetLines(2, 3, 5, [new("Greg", "Goldsmith")]);
            var x = JsonConvert.SerializeObject(result);
            var expected = GetExpected("Service_PrintsJustNumber_WhenNotDivisibleBy3or5.txt");
            Assert.Equal(expected, result);
            Assert.True(result.Count == 2);
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
                NumberAndNameService.GetLines(15, invalidDivisor1, invalidDivisor2, names));
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
                NumberAndNameService.GetLines(15, invalidDivisor1, invalidDivisor2, names));
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
                NumberAndNameService.GetLines(15, invalidDivisor1, invalidDivisor2, names));
        }

        private static List<string>? GetExpected(string fileName)
        {
            var filePath = Path.Combine(TestDataFolder, fileName);
            var fileContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<string>>(fileContent);
        }
    }
}