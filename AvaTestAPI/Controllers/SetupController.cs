using AvaTestAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace AvaTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupController : ControllerBase
    {
        public SetupController()
        {
        }

        //[HttpGet]
        //[Route("{host}/{port}/{dbName}/{username}/{password}")]
        //public virtual async Task<IActionResult> SetupContext(string host, string port, string dbName, string username, string password)
        //{
        //    if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(port) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        //    {
        //        HttpContext.Response.ContentType = "text/plain";
        //        return BadRequest("Invalid database params (some param is empty)");
        //    }

        //    if (g.DatabaseSettings != null)
        //    {
        //        if (g.DatabaseSettings.DatabaseHost     == host     &&
        //            g.DatabaseSettings.DatabasePort     == port     &&
        //            g.DatabaseSettings.DatabaseName     == dbName   &&
        //            g.DatabaseSettings.DatabaseUsername == username &&
        //            g.DatabaseSettings.DatabasePassword == password)
        //            return Ok(true);
        //    }

        //    g.DatabaseSettings = new DatabaseSettings(host, port, dbName, username, password);

        //    var ctx = new TagContext();
        //    if (ctx.IsValid)
        //    {
        //        await ctx.DisposeAsync();
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        g.DatabaseSettings               = null;
        //        HttpContext.Response.ContentType = "text/plain";
        //        return BadRequest($"Invalid database params\n{string.Join("\n", ctx.Exception.FromChain(_ => _.InnerException).Select(_ => _.Message))}");
        //    }
        //}
        [HttpGet]
        [Route("EnsureDeleted")]
        public virtual void EnsureDeleted()
        {
            new MainContext(true);
        }
    }
}
