using System.Security.Cryptography;
using System.Text;

namespace Helpers;

public static class Hash
{
    public static byte[] HashText(string text)
    {
        byte[] bs = Encoding.UTF8.GetBytes(text);
        using var hash = SHA1.Create();

        return hash.ComputeHash(bs);
    }

    public static byte[] HashFile(string file)
    {
        using FileStream fs = new(file, FileMode.Open, FileAccess.Read, FileShare.Read);
        using BufferedStream bs = new(fs);
        using var hash = SHA1.Create();

        return hash.ComputeHash(bs);
    }
}
