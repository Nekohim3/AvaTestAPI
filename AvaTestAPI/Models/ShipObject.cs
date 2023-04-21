using Newtonsoft.Json;

namespace AvaTestAPI.Models;

[JsonObject]
public class ShipObject : ChangeInfoEntity
{
    public Guid   GuidParent   { get; set; }
    public string Name         { get; set; }
    public Guid   GuidShip     { get; set; }
    public string SerialNumber { get; set; }

    public virtual Ship                     Ship         { get; set; }
    public virtual ShipObject?              ParentObject { get; set; }
    public virtual ICollection<ShipObject>? Objects      { get; set; }

    public virtual ICollection<Job>? Jobs { get; set; }
}