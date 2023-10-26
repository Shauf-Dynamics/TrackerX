namespace TrackerX.Core.Cryptography
{
    public interface IPasswordHashProvider
    {
        string Hash(string input);

        bool Verify(string input, string hashString);
    }
}
