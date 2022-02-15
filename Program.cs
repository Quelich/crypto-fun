using System;
using System.Text;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;


public class Program
{

    public static void Main(String[] args)
    {
        var mode = new Program();
        string input = "Emre";

        var r0 = mode.EncryptSha256(input);
        Console.WriteLine(string.Format("{0}\n{1}", "SHA256",r0));
        var r1 = mode.EncryptBlake2B(input);
          Console.WriteLine(string.Format("{0}\n{1}", "Blake2",r1));
        var r2 = mode.EncryptArgon2(input);
         Console.WriteLine(string.Format("{0}\n{1}", "Argon2",r2));
    }
    public string EncryptSha256(string input)
    {
        if (input == "" && input == null)
            throw new Exception("Input is empty");
        var sha256Hash = SHA256.Create();
        var computeHash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    public string EncryptBlake2B(string input)
    {
        if (input == "" && input == null)
            throw new Exception("Input is empty");

        var b2bHash = new HMACBlake2B(512);
        b2bHash.Initialize();
        var computeHash = b2bHash.ComputeHash(Encoding.UTF8.GetBytes(input));
        // Convert byte array to a string   
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    public string EncryptArgon2(string input)
    {
        if (input == "" && input == null)
            throw new Exception("Input is empty");
        byte[] salt = new byte[16];
        // byte[] userUuidBytes;

        var arg2Hash = new Argon2d(Encoding.UTF8.GetBytes(input));
        arg2Hash.DegreeOfParallelism = 16;
        arg2Hash.MemorySize = 8192;
        arg2Hash.Iterations = 40;
        arg2Hash.Salt = salt;
        // arg2Hash.AssociatedData = userUuidBytes;
        var computeHash = arg2Hash.GetBytes(128);
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    //Helper method to convert byte array to a string
    private string ByteToString(byte[] byteData)
    {
        StringBuilder builder = new StringBuilder();
        Array.ForEach(byteData, b => builder.Append(b.ToString("x2")));
        return builder.ToString();
    }

    public string GenerateSalt()
    {
        var rng = RandomNumberGenerator.Create();
        byte[]? salt = new byte[32];
        rng.GetBytes(salt);
        string? token = Convert.ToBase64String(salt);
        return token;
    }
}