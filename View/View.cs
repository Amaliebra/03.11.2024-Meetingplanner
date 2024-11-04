using Meetingplanner.Controller;

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
        string Title = Console.ReadLine()?.Trim() ?? "Unknown meeting name";

        Console.WriteLine("Enter start time for meeting (yyyy-mm-dd hh-mm)");
        string StartTime = Console.ReadLine()?.Trim() ?? "2024-11-04 00.00";

        Console.WriteLine("Enter end of meeting in format HH-hh");
        string EndTime = Console.ReadLine()?.Trim() ?? "00.00";

        Console.WriteLine("Who is participating in the meeting?");
        string Participants = Console.ReadLine()?.Trim() ?? "Unknown";
    }
}

