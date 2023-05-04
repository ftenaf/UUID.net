using Org.BouncyCastle.Security;
using System;

namespace UUID.Providers
{
    /// <summary>
    /// Helper class to generate cryptographically strong numbers on .NET portable
    /// </summary>
    public partial class RandomNumberProvider
    {
        private SecureRandom random = new SecureRandom();

        private void FillCryptoBytes(byte[] bytes)
        {
            random.NextBytes(bytes); // generates 8 random bytes
        }

        private RandomNumberMode _mode { get; set; }
        public RandomNumberMode Mode { get { return _mode; } }

        private static Random _pseudoRandom = new Random();

        public RandomNumberProvider(RandomNumberMode mode = RandomNumberMode.Crypro)
        {
            _mode = mode;
        }

        public void FillBytes(byte[] bytes)
        {
            if (Mode == RandomNumberMode.Pseudo)
            {
                _pseudoRandom.NextBytes(bytes);
            }
            else
            {
                FillCryptoBytes(bytes);
            }
        }
    }
}
