using Meetingplanner.Controller;
using Meetingplanner.Models;
using System.Linq;

namespace Meetingplanner.View;

public class MeetingView
{
    private readonly MeetingController _controller;

    public MeetingView(MeetingController controller)
    {
        _controller = controller;
    }

    public void AddMeeting()
    {
        string title = "unknown meeting name";
        string day = "unspecified day";
        TimeOnly startTime = TimeOnly.MinValue;
        TimeOnly endTime = TimeOnly.MinValue;
        List<string> participants = new List<string>();

        try
        {
            Console.WriteLine("Enter meeting title:");
            title = Console.ReadLine()?.Trim() ?? "Unknown meeting name";

            Console.WriteLine("Enter day of the meeting: ");
            day = Console.ReadLine()?.Trim() ?? "unspecified day";

            Console.WriteLine("Enter start of meeting in format HH-mm");
            startTime = TimeOnly.Parse(Console.ReadLine()
            .Replace(",", ":").Replace(".", ":").Replace(" ", ":"));

            Console.WriteLine("Enter end of meeting in format HH-mm");
            endTime = TimeOnly.Parse(Console.ReadLine()
            .Replace(",", ":").Replace(".", ":").Replace(" ", ":"));

            Console.WriteLine("Who is participating in the meeting? (separate with ',')");
            participants = Console.ReadLine()?.Split(',')
            .Select(p => p.Trim()).ToList() ?? new List<string>();
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid input format");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
        }

        var meeting = new Meeting
        {
            Title = title,
            Day = day,
            StartTime = startTime,
            EndTime = endTime,
            Participants = participants
        };

        _controller.AddMeeting(meeting);
    }

    public void DisplayMeetings()
    {
        var meetings = _controller.GetAllMeetings();

        if (meetings.Count == 0)
        {
            Console.WriteLine("No meetings scheduled today");
            return;
        }

        foreach (var meeting in meetings)
        {
            DisplayMeetingDetails(meeting);
        }
    }

    private void DisplayMeetingDetails(Meeting meeting)
    {
        Console.WriteLine($"Meeting: {meeting.Title}");
        Console.WriteLine($"Day: {meeting.Day}");
        Console.WriteLine($"Start Time: {meeting.StartTime}");
        Console.WriteLine($"End Time: {meeting.EndTime}");
        Console.WriteLine($"Participants: {string.Join(",", meeting.Participants)}");
        Console.WriteLine($"");
    }

    public void SearchMeetingsParticipant()
    {
        Console.WriteLine("Enter meeting participant");
        string? participant = Console.ReadLine();

        var meetings = _controller.GetListByParticipant(participant);

        if (meetings.Count == 0)
        {
            Console.WriteLine($"No meetings found for: {participant}");
            return;
        }

        Console.WriteLine($"Meetings for {participant}: ");
        foreach (var meeting in meetings)
        {
            DisplayMeetingDetails(meeting);
        }
    }
}

