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

        Console.WriteLine("Enter start time for meeting  hh-mm");
        string startTime = Console.ReadLine()?.Trim() ?? "00.00";

        Console.WriteLine("Enter end of meeting in format HH-hh");
        string endTime = Console.ReadLine()?.Trim() ?? "01.00";

        Console.WriteLine("Who is participating in the meeting?(seperate with','");
        List<string> participants = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();

        var meeting = new Meeting
        {
            Title = title,
            StartTime = startTime,

        };
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
            DisplayMeeting(meeting);
        }
    }
}

