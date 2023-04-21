using Newtonsoft.Json;

namespace AvaTestAPI.Models;

public enum JobOperationType
{
    Start   = 0,
    Stop    = 1,
    Execute = 2
}
[JsonObject]
public class JobHistoryRecord : ChangeInfoEntity
{
    public Guid             GuidJob       { get; set; }
    public DateTime         OperationDate { get; set; }
    public JobOperationType OperationType { get; set; }

    public virtual Job Job { get; set; }
}