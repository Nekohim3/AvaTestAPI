using AvaTestAPI.Context;
using AvaTestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvaTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipsController : GuidTController<Ship>
    {
        public ShipsController(MainContext ctx) : base(ctx)
        {
            
        }
    }
}
