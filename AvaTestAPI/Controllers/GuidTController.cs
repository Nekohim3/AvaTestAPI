using AvaTestAPI.Context;
using AvaTestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvaTestAPI.Controllers
{
    public class GuidTController<T> : ControllerBase where T : GuidEntity
    {
        protected readonly MainContext Context;
        protected GuidTController(MainContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var lst = await Context.Set<T>().AsNoTracking().ToListAsync();
            return Ok(lst);
        }

        [HttpGet]
        [Route("{guid}")]
        public virtual async Task<IActionResult> Get(Guid guid)
        {
            var t = await Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(_ => _.Id == guid);
            if (t == null)
                return NotFound();
            return Ok(t);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T t)
        {
            Context.Add(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPost]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Create(List<T> tList)
        {
            Context.AddRange(tList);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(T t)
        {
            Context.Update(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPut]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Update(List<T> tList)
        {
            Context.UpdateRange(tList);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Save(T t)
        {
            if (t.Id == default)
                Context.Add(t);
            else
                Context.Update(t);
            await Context.SaveChangesAsync();
            return Ok(t);
        }

        [HttpPatch]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Save(List<T> tList)
        {
            var forAdd = tList.Where(_ => _.Id == default).ToList();
            var forSave = tList.Where(_ => _.Id != default).ToList();
            Context.AddRange(forAdd);
            Context.UpdateRange(forSave);
            await Context.SaveChangesAsync();
            return Ok(tList);
        }

        [HttpDelete]
        [Route("{guid}")]
        public virtual async Task<IActionResult> Delete(Guid guid)
        {
            var t = await Context.Set<T>().FindAsync(guid);
            if (t == null)
                return NotFound();
            Context.Remove(t);
            await Context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete]
        [Route("Bulk")]
        public virtual async Task<IActionResult> Delete(List<Guid> ids)
        {
            var t = await Context.Set<T>().Where(_ => ids.Contains(_.Id)).ToListAsync();
            if (t.Count != ids.Count)
                return NotFound();
            Context.RemoveRange(t);
            await Context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
