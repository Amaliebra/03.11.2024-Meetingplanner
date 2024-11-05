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
        Console.WriteLine("Enter meeting title:");
        string title = Console.ReadLine()?.Trim() ?? "Unknown meeting name";

        Console.WriteLine("Enter day of the meeting: ");
        string day = Console.ReadLine()?.Trim() ?? "unspecified day";

        Console.WriteLine("Enter start of meeting in format HH-mm");
        TimeOnly startTime = TimeOnly.Parse(Console.ReadLine()
        .Replace(",", ":").Replace(".", ":").Replace(" ", ":"));

        //?.Trim() ??"00:00"
        Console.WriteLine("Enter end of meeting in format HH-mm");
        TimeOnly endTime = TimeOnly.Parse(Console.ReadLine()
        .Replace(",", ":").Replace(".", ":").Replace(" ", ":"));

        Console.WriteLine("Who is participating in the meeting?(seperate with','");
        List<string> participants = Console.ReadLine()?.Split(',').Select(p => p.Trim()).ToList() ?? new List<string>();

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

