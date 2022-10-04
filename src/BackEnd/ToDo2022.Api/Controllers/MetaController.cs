using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ToDo2022.Api.Controllers
{
    [ApiController]
    [Route("v1/Meta")]
    public partial class MetaController : ControllerBase, IEzControllerBase
    {
        public readonly ILogger<MetaController> _logger;
        public DbContext Context { get; set; }
        public string Entity { get; set; } = "Meta";
        public string Domain { get; set; } = "TODO";
        public MetaController(ILogger<MetaController> logger, ApplicationDbContext dbcontext)
        {
            _logger = logger;
            Context = dbcontext;
        }

        #region "Sección Estandarizada y generica"
        [HttpGet("{id}")] public async Task<ActionResult<object>> GetAsync(int id) => (await OptionsCrudAsync(null, "GET",id));
        [HttpPut("{id}")] public async Task<ActionResult<object>> PutAsync(Meta__Dto dto, int id, string mode) => (await OptionsCrudAsync(dto, "PUT", id));
        [HttpPost] public async Task<ActionResult<object>> PostAsync(Meta__Dto dto) => (await OptionsCrudAsync(dto, "POST"));
        [HttpDelete("{id}")] public async Task<ActionResult<object>> DeleteAsync(int id) => (await OptionsCrudAsync(null, "DELETE",id));

        [HttpGet("DataItems")] public async Task<ActionResult<object>> GetDataItemsAsync(string? pqry = "$", int? offsetskip = -1, int? limittake = -1)
        {
            return await EzController_MsSQL.GetDataItemsAsync<Meta__Dto>(this, pqry, offsetskip, limittake, 
                async (sQryExecuted, sQryCount) => {
                    DbSet<Meta> dbset = ((ApplicationDbContext)Context).Meta;
                    int count = dbset.FromSqlRaw(sQryCount).Count();
                    List<Meta__Dto> items = dbset.FromSqlRaw(sQryExecuted).ToList().MapTo<List<Meta__Dto>>();
                    items = dbset.FromSqlRaw(sQryExecuted).ToList().MapTo<List<Meta__Dto>>();
                    return (items, count);
                });
        }

        [HttpGet("CountItems")] public async Task<ActionResult<int>> GetCountItemsAsync(string? pqry = "$")
        {
            return await EzController_MsSQL.GetCountItemsAsync<Meta__Dto>(this, pqry,
                async (sQryCount) => {
                    DbSet<Meta> dbset = ((ApplicationDbContext)Context).Meta;
                    int count = dbset.FromSqlRaw(sQryCount).Count();
                    return (count);
                });
        }

        [HttpOptions]
        public async Task<ActionResult<object>> OptionsCrudAsync(Meta__Dto? dto, string mode, int? id = null)
        {
            return await EzController_MsSQL.OptionsCrudAsync<Meta__Dto>(this, mode, dto,
            async (mode, dto) =>
            {
                Meta entry = null;
                if (mode == "POST")
                {
                    entry = dto.MapTo<Meta>();
                    entry.Created = DateTime.Now;
                }
                DbSet<Meta> dbset = ((ApplicationDbContext)Context).Meta;


                // Codigo Generico..
                if (mode == "GET") entry = await dbset.SingleAsync(x => x.Id == id);
                if (mode == "DELETE" || mode == "PUT") entry = await dbset.AsTracking().SingleAsync(x => x.Id == id);
                if (mode == "POST") await dbset.AddAsync(entry);
                if (mode == "DELETE" && entry != null) Context.Remove(entry);
                if (mode == "PUT" && entry != null) dto.Transfer(ref entry);
                await Context.SaveChangesAsync();

                //if (mode != "GET") await this.RefreshAsync(entry.Id);
                return entry;
            });
        }
        # endregion
    }
}