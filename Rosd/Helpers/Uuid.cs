using System.Text;

using static Helpers.Hash;

namespace Helpers;

public static class Uuid
{
    public const string Empty = "00000000-0000-7000-0000-000000000000"; //instead of Guid.Empty
    
    const char separator = '-';

    public static string Uuid5(string text)
        => Uuid5(HashText(text));

    public static string Uuid5(DirectoryInfo di) 
        => Uuid5(HashText(di.FullName));

    public static string Uuid5(FileInfo fi) 
        => Uuid5(HashFile(fi.FullName));

    public static string Uuid5(byte[] hash)
    {
        const string format = "{0:x2}";

        StringBuilder sb = new(32);
        byte b;

        //00000000-0000-0000-0000-000000000000
        //0 1 2 3  4 5  6 7  8 9  10        16

        for (int i = 0; i < 16; i++)
        {
            b = hash[i];

            switch (i)
            {
                case 4:
                case 10:
                    sb.Append(separator);
                    break;

                case 6: //set high-nibble to 5 to indicate type 5
                    b &= 0x0F;
                    b |= 0x50;
                    sb.Append(separator);
                    break;

                case 8: //set upper two bits to "10"
                    b &= 0x3F;
                    b |= 0x80;
                    sb.Append(separator);
                    break;
            }

            sb.AppendFormat(format, b);
        }

        return sb.ToString();
    }

    public static string Uuid7(DateTime date, int num, string code = "000")
    {
        // "00000000-0000-7000-0000-000000000000"
        string random = Guid.NewGuid().ToString();
        StringBuilder sb = new(36);
        sb.AppendFormat("{0:yyyyMMdd}-", date);

        if (num > 9999)
        {
            sb.AppendFormat("{0:x4}", num);
        }
        else
        {
            sb.AppendFormat("{0:0000}", num);
        }

        sb.Append("-7").Append(code).Append(random.AsSpan(18));

        return sb.ToString();
    }
}
