using Newtonsoft.Json;

namespace AvaTestAPI.Models;

[JsonObject]
public class Ship : ChangeInfoEntity
{
    public string ShipName { get; set; }
    public string ShipImo  { get; set; }
    public bool   IsActive { get; set; }
    public string Note     { get; set; }
    public ulong   LastCounter { get; set; }

    public virtual ICollection<ShipObject>? Objects { get; set; }
}