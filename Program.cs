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
        string r0 = mode.EncryptSha256(input);
        Console.WriteLine(r0);
        string r1 = mode.EncryptBlake2B(input);
        System.Console.WriteLine(r1);
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


    //Helper method to convert byte array to a string
    private string ByteToString(byte[] byteData)
    {
        StringBuilder builder = new StringBuilder();
        Array.ForEach(byteData, b => builder.Append(b.ToString("x2")));
        return builder.ToString();
    }
}