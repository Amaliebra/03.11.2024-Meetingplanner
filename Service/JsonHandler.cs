using Newtonsoft.Json;
using Meetingplanner.Controller;
using Meetingplanner.Models;

namespace Meetingplanner.Service;

public class WriteToJson
{

    // public void SaveMeetings(string filePath, List<Meeting> meetings)
    // {
    //     var MeetingsJson = JsonConvert.SerializeObject(meetings);
    //     File.WriteAllText(filePath, MeetingsJson);
    // }

    // public void LoadMeetings(string filePath, List<Meeting> meetings)
    // {
    //     if (File.Exists(filePath))
    //     {
    //         var MeetingsJson = File.ReadAllText(filePath);
    //         meetings = JsonConvert.DeserializeObject<List<Meeting>>(MeetingsJson) ?? new List<Meeting>();

    //     }
    // }
}
