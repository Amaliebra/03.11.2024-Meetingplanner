using Meetingplanner.Controller;

namespace Meetingplanner.Models;
public class Meeting
{
    public string? Title { get; set; }
    public List<string>? Participants { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
