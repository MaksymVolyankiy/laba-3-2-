using System;
using System.Text.Json;

public class Time
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public int GetTimeDifferenceInSeconds(Time otherTime)
    {
        int thisTimeInSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        int otherTimeInSeconds = otherTime.Hours * 3600 + otherTime.Minutes * 60 + otherTime.Seconds;

        return Math.Abs(thisTimeInSeconds - otherTimeInSeconds);
    }

    public void AddSeconds(int seconds)
    {
        int totalSeconds = Hours * 3600 + Minutes * 60 + Seconds;
        totalSeconds += seconds;

        Hours = totalSeconds / 3600;
        Minutes = (totalSeconds % 3600) / 60;
        Seconds = totalSeconds % 60;
    }

    public static void Main()
    {

        Time time = new Time(11, 30, 47);
        string json = JsonSerializer.Serialize(time);
        File.WriteAllText("time.json", json);
        string jsonFromFile = File.ReadAllText("time.json");
        Time timeFromFile = JsonSerializer.Deserialize<Time>(jsonFromFile);

        Time time1 = timeFromFile;
        Time time2 = new Time(12, 44, 30);

        int timeDifference = time1.GetTimeDifferenceInSeconds(time2);
        Console.WriteLine($"Рiзниця в секундах мiж часом 1 i часом 2: {timeDifference}");
        time1.AddSeconds(120);
        Console.WriteLine($"Час 1 пiсля додавання 120 секунд: {time1.Hours}:{time1.Minutes}:{time1.Seconds}");
    }
}
