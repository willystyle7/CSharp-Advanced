using System;
using System.Globalization;
using System.Text.RegularExpressions;

class PINValidation
{
    static void Main()
    {
        string name = Console.ReadLine();
        string gender = Console.ReadLine();
        string PINstr = Console.ReadLine();
        string patternName = @"^[A-Z][a-z]+\s+[A-Z][a-z]+$";
        string patternPIN = @"^[0-9]{10}$";
        Match matchName = Regex.Match(name, patternName);
        Match matchPin = Regex.Match(PINstr, patternPIN);
        if (!matchName.Success || !matchPin.Success || (gender != "male" && gender != "female"))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        //validate PIN
        long PINnum = long.Parse(PINstr);
        int checksum = 0;
        int[] multilpiers = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        for (int i = 0; i < 9; i++)
        {
            checksum += multilpiers[i] * (PINstr[i] - '0');
        }
        int remainder = checksum % 11;
        int lastDigit = (int)(PINnum % 10);
        remainder = (remainder == 10) ? 0 : remainder;
        if (remainder != lastDigit)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        if (((PINstr[8] - '0') % 2 == 0 && gender == "female") || ((PINstr[8] - '0') % 2 == 1 && gender == "male"))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        //validate date
        int yy = (PINstr[0] - '0') * 10 + (PINstr[1] - '0');
        int yyyy = 0;
        int mm = (PINstr[2] - '0') * 10 + (PINstr[3] - '0');
        int dd = (PINstr[4] - '0') * 10 + (PINstr[5] - '0');
        if (mm <= 12)
        {
            yyyy = 1900 + yy;
        }
        else if (mm > 20 && mm <= 32)
        {
            yyyy = 1800 + yy;
            mm = mm - 20;
        }
        else if (mm > 40 && mm <= 52)
        {
            yyyy = 2000 + yy;
            mm = mm - 40;
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        string birthdayStr = string.Format("{0:D2}-{1:D2}-{2}", dd, mm, yyyy);
        DateTime birthday = new DateTime();
        if (!DateTime.TryParseExact(birthdayStr, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", name, gender, PINstr);
    }
}

