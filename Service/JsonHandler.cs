using Newtonsoft.Json;
using Meetingplanner.Controller;
using Meetingplanner.Models;

namespace Meetingplanner.Service;

public class WriteToJson
{
    string JsonString = JsonConvert.SerializeObject(meeting);
}
