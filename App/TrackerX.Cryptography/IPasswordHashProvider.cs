﻿namespace TrackerX.Cryptography;

public interface IPasswordHashProvider
{
    string Hash(string input);

    bool Verify(string input, string hashString);
}
