using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;

class ChatLogger
{
    static void Main()
    {
        string format = "dd-MM-yyyy HH:mm:ss";
        DateTime now = DateTime.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);
        SortedDictionary<DateTime, string> chatLog = new SortedDictionary<DateTime, string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] token = input.Split(new[] { " / "}, StringSplitOptions.RemoveEmptyEntries);
            string message = token[0].Trim();
            string datetime = token[1].Trim();
            DateTime Datetime = DateTime.ParseExact(datetime, format, CultureInfo.InvariantCulture);
            chatLog[Datetime] = message;
        }
        foreach (var message in chatLog)
        {
            Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(message.Value));
        }
        DateTime lastTime = chatLog.Keys.Last();       
        TimeSpan difference = now - lastTime;        
        string timestamp = string.Empty;        
        if (DateTime.Compare(now.Date, lastTime.Date) == 0)
        {
            if (difference.TotalHours < 1.0 && difference.TotalMinutes < 1.0)
            {
                timestamp = "a few moments ago";
            }
            else if (difference.TotalHours < 1.0)
            {
                timestamp = (int)difference.TotalMinutes + " minute(s) ago";
            }
            else
            {
                timestamp = (int)difference.TotalHours + " hour(s) ago";

            }
        }
        else if (DateTime.Compare(now.Date, lastTime.Date.AddDays(1.0)) == 0) 
        {
            timestamp = "yesterday";
        }
        else
        {
            timestamp = lastTime.Date.ToString("dd-MM-yyyy");
        }
        Console.WriteLine("<p>Last active: <time>{0}</time></p>", timestamp);
    }
}

