using AvaTestAPI.Context;
using AvaTestAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvaTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuidController : ControllerBase
    {
        protected readonly MainContext Context;

        public GuidController(MainContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        [Route("{shipId}")]
        public virtual async Task<IActionResult> Get(Guid shipId)
        {
            var ship = await Context.Ships.FirstOrDefaultAsync(_ => _.Id == shipId);
            if (ship == null)
                return BadRequest();
            if (ship.LastCounter == default)
                return Ok(GetGuid(GetShipId(shipId), 0));
                //return Ok(new Guid(shipId.ToByteArray().Skip(14).Take(2).ToArray()));
            return Ok(ship.LastCounter);
        }

        private Guid GetGuid(ushort shipId, ulong entityId)
        {
            var bytes = BitConverter.GetBytes(shipId).ToList();
            bytes.AddRange(new List<byte>()
                           {
                               0,
                               0,
                               0,
                               0,
                               0,
                               0
                           });
            bytes.AddRange(BitConverter.GetBytes(entityId));
            return new Guid(bytes.ToArray());
        }


        private ushort GetShipId(Guid guid)
        {
            return BitConverter.ToUInt16(guid.ToByteArray().Take(2).ToArray(), 0);
        }

        private ulong GetEntityId(Guid guid)
        {
            return BitConverter.ToUInt16(guid.ToByteArray(), 8);
        }
    }
}
