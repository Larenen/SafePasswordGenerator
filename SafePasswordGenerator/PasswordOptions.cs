namespace SafePasswordGenerator
{
    public class PasswordOptions
    {
        public PasswordOptions(
            int requiredLength = 8,
            int requiredUniqueChars = 4,
            bool requireDigit = true,
            bool requireUppercase = true,
            bool requireNonAlphanumeric = true)
        {
            RequiredLength = requiredLength;
            RequiredUniqueChars = requiredUniqueChars;
            RequireDigit = requireDigit;
            RequireUppercase = requireUppercase;
            RequireNonAlphanumeric = requireNonAlphanumeric;
        }

        public int RequiredLength { get; }
        public int RequiredUniqueChars { get; }
        public bool RequireDigit { get; }
        public bool RequireUppercase { get; }
        public bool RequireNonAlphanumeric { get; }
    }
}
