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



    }
}

