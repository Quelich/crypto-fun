using System.Text;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

public class Qcrypto
{

    public string Input { get; private set; }
    public uint SaltSize { get; private set; }

    public Qcrypto(string input, uint saltSize)
    {
        Input = input;
        SaltSize = saltSize;
    }

    // Generate hash using SHA256 function
    // A salt value is provided 
    public string EncryptSha256()
    {
        if (Input == "" && Input == null)
            throw new Exception("Input is empty");
        var sha256Hash = SHA256.Create();
        var salt = GenerateSalt(SaltSize);
        byte[] encoded = Encoding.UTF8.GetBytes(Input + salt);
        var computeHash = sha256Hash.ComputeHash(encoded);
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    // Generate hash using Blake2B function
    // The function creates salt itself.
    public string EncryptBlake2B(int bc)
    {
        if (Input == "" && Input == null)
            throw new Exception("Input is empty");
        byte[] salt = new byte[SaltSize];
        var b2bHash = new HMACBlake2B(salt, bc);
        b2bHash.Initialize();
        var computeHash = b2bHash.ComputeHash(Encoding.UTF8.GetBytes(Input));
        // Convert byte array to a string   
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    // Generate hash using Argon2 function
    // The function creates salt itself.
    public string EncryptArgon2(int bc)
    {
        if (Input == "" && Input == null)
            throw new Exception("Input is empty");
        byte[] salt = new byte[SaltSize];
        // byte[] userUuidBytes;
        var arg2Hash = new Argon2d(Encoding.UTF8.GetBytes(Input));
        arg2Hash.DegreeOfParallelism = 16;
        arg2Hash.MemorySize = 8192;
        arg2Hash.Iterations = 40;
        arg2Hash.Salt = salt;
        // arg2Hash.AssociatedData = userUuidBytes;
        var computeHash = arg2Hash.GetBytes(bc);
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    // Generate hash using HMACSHA256 function
    public string EncryptHMACSHA256(string key)
    {
        if (Input == "" && Input == null)
            throw new Exception("Input is empty");
        var input = Input;
        Encoding enc = Encoding.UTF8;
        Byte[] inputBytes = enc.GetBytes(input);
        Byte[] keyBytes = enc.GetBytes(key);
        HMACSHA256 hMACSHA256Hash = new HMACSHA256(keyBytes);
        Byte[] computeHash = hMACSHA256Hash.ComputeHash(inputBytes);
        var hashStr = ByteToString(computeHash);
        return hashStr;
    }

    //Convert byte array, hash code, to a string
    private string ByteToString(byte[] byteData)
    {
        StringBuilder builder = new StringBuilder();
        Array.ForEach(byteData, b => builder.Append(b.ToString("x2")));
        return builder.ToString();
    }

    // Generate salt for hash codes
    private byte[] GenerateSalt(uint size)
    {
        var rng = RandomNumberGenerator.Create();
        byte[]? salt = new byte[size];
        rng.GetBytes(salt);
        return salt;
    }

    private string GenerateSalt(byte[] salt)
    {
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        string? token = Convert.ToBase64String(salt);
        return token;
    }
}

internal class Program
{
    public static void Main(String[] args)
    {
        string input = "Emre";
        var instance = new Qcrypto(input, 16);


        var result_0 = instance.EncryptSha256();
        Console.WriteLine(string.Format("{0}\n{1}", "SHA256", result_0));
        var result_1 = instance.EncryptBlake2B(256);
        Console.WriteLine(string.Format("{0}\n{1}", "Blake2B", result_1));
        var result_2 = instance.EncryptArgon2(128);
        Console.WriteLine(string.Format("{0}\n{1}", "Blake2B", result_2));
        System.Console.WriteLine("\nHMACSHA256");
         var result_3 = instance.EncryptHMACSHA256("1");
         var result_4 = instance.EncryptHMACSHA256("2");
         Console.WriteLine(string.Format("{0}\n{1}", result_3, result_4));
    }

}