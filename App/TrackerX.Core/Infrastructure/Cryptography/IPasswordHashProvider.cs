namespace TrackerX.Core.Infrastructure.Cryptography
{
    internal interface IPasswordHashProvider
    {
        string Hash(string input);

        bool Verify(string input, string hashString);
    }
}
