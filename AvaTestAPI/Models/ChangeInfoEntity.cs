using Newtonsoft.Json;

namespace AvaTestAPI.Models;

[JsonObject]
public class ChangeInfoEntity : GuidEntity
{
    public DateTime AddTime    { get; set; }
    public DateTime ChangeTime { get; set; }
}