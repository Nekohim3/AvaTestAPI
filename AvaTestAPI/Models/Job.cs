using Newtonsoft.Json;

namespace AvaTestAPI.Models;

[JsonObject]
public class Job : ChangeInfoEntity
{
    public Guid   GuidObject  { get; set; }
    public string Name        { get; set; }
    public string Description { get; set; }

    public virtual ShipObject                     ShipObject        { get; set; }
    public virtual ICollection<JobHistoryRecord>? JobHistoryRecords { get; set; }
}