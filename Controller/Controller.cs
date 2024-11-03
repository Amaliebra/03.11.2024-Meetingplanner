using Meetingplanner.Models;
using Meetingplanner.View;

namespace Meetingplanner.Controller;

public class MeetingController
{
    private List<Meeting> _meetings = new List<Meeting>();

    public void AddMeeting(Meeting meeting)
    {
        _meetings.Add(meeting);
        Console.WriteLine("Meeting added");
    }
}