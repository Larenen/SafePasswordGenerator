using System.Linq;
using FluentAssertions;
using Xunit;

namespace SafePasswordGenerator.Tests
{
    public class SafePasswordGeneratorTests
    {
        [Fact]
        public void ShouldGeneratePasswordWithRequiredLengthOf10()
        {
            var expectedLength = 10;
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(expectedLength));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Length.Should().Be(expectedLength);
        }

        [Fact]
        public void ShouldGeneratePasswordWithRequiredLengthOf5()
        {
            var expectedLength = 5;
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(expectedLength));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Length.Should().Be(expectedLength);
        }

        [Fact]
        public void ShouldGeneratePasswordWithAtLeastProvidedeUniquesOf5()
        {
            var minimalExpectedUniques = 5;
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requiredUniqueChars: minimalExpectedUniques));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Distinct().Count().Should().BeGreaterOrEqualTo(minimalExpectedUniques);
        }

        [Fact]
        public void ShouldGeneratePasswordWithAtLeastProvidedeUniquesOf8()
        {
            var minimalExpectedUniques = 8;
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requiredUniqueChars: minimalExpectedUniques));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Distinct().Count().Should().BeGreaterOrEqualTo(minimalExpectedUniques);
        }

        [Fact]
        public void ShouldGeneratePasswordWithDigit()
        {
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requireDigit: true));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Should().ContainAny("0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
        }

        [Fact]
        public void ShouldGeneratePasswordWithoutDigit()
        {
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requireDigit: false));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Should().NotContainAny("0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
        }

        [Fact]
        public void ShouldGeneratePasswordWithUpercaseLetter()
        {
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requireUppercase: true));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Should().MatchRegex("([A-Z])");
        }

        [Fact]
        public void ShouldGeneratePasswordWithoutUpercaseLetter()
        {
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requireUppercase: false));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Should().NotMatchRegex("([A-Z])");
        }

        [Fact]
        public void ShouldGeneratePasswordWithSpecialChar()
        {
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requireNonAlphanumeric: true));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Should().ContainAny("!", "@", "#", "$", "_", "-");
        }

        [Fact]
        public void ShouldGeneratePasswordWithoutSpecialChar()
        {
            using var passwordGenerator = new RandomPasswordGenerator(new PasswordOptions(requireNonAlphanumeric: false));

            var generatedPassword = passwordGenerator.Generate();

            generatedPassword.Should().NotContainAny("!", "@", "#", "$", "_", "-");
        }
    }
}
