using Newtonsoft.Json;
using Meetingplanner.Controller;
using Meetingplanner.Models;

namespace Meetingplanner.Service;

public class WriteToJson
{

    public void SaveMeetings(string filePath, List<Meeting> meetings)
    {
        var MeetingsJson = JsonConvert.SerializeObject(meetings);
        File.WriteAllText(filePath, MeetingsJson);
    }
}
