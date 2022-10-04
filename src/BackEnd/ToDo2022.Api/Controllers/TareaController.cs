namespace ToDo2022.Api.Controllers
{
    [ApiController]
    [Route("v1/Tarea")]
    public partial class TareaController : ControllerBase, IEzControllerBase
    {
        public readonly ILogger<TareaController> _logger;
        public DbContext Context { get; set; }
        public string Entity { get; set; } = "Tarea";
        public string Domain { get; set; } = "TODO";
        public TareaController(ILogger<TareaController> logger, ApplicationDbContext dbcontext)
        {
            _logger = logger;
            Context = dbcontext;
        }

        [HttpGet("{id}")] public async Task<ActionResult<object>> GetAsync(int id) => (await OptionsCrudAsync(null, "GET",id));
        [HttpPut("{id}")] public async Task<ActionResult<object>> PutAsync(Tarea__Dto dto, int id, string mode) => (await OptionsCrudAsync(dto, "PUT", id));
        [HttpPost] public async Task<ActionResult<object>> PostAsync(Tarea__Dto dto) => (await OptionsCrudAsync(dto, "POST"));
        [HttpDelete("{id}")] public async Task<ActionResult<object>> DeleteAsync(int id) => (await OptionsCrudAsync(null, "DELETE",id));
        [HttpGet("DataItems")] public async Task<ActionResult<object>> GetDataItemsAsync(string? pqry = "$", int? offsetskip = -1, int? limittake = -1)
        {
            return await EzController_MsSQL.GetDataItemsAsync<Tarea__Dto>(this, pqry, offsetskip, limittake,
                async (sQryExecuted, sQryCount) => {
                    DbSet<Tarea> dbset = ((ApplicationDbContext)Context).Tarea;
                    int count = -1; if (sQryCount != "") count = dbset.FromSqlRaw(sQryCount).Count();
                    List<Tarea__Dto> items = dbset.FromSqlRaw(sQryExecuted).ToList().MapTo<List<Tarea__Dto>>();
                    return (items, count);
                });
        }
        [HttpGet("CountItems")] public async Task<ActionResult<int>> GetCountItemsAsync(string? pqry = "$")
        {
            return await EzController_MsSQL.GetCountItemsAsync<Tarea__Dto>(this, pqry,
                async (sQryCount) => {
                    DbSet<Tarea> dbset = ((ApplicationDbContext)Context).Tarea;
                    int count = dbset.FromSqlRaw(sQryCount).Count();
                    return (count);
                });
        }

        [HttpOptions]
        public async Task<ActionResult<object>> OptionsCrudAsync(Tarea__Dto? dto, string mode, int? id=null)
        {
            return await EzController_MsSQL.OptionsCrudAsync<Tarea__Dto>(this, mode, dto,
            async (mode, dto) =>
            {
                Tarea entry = null;
                if (mode == "POST")
                {
                    entry = dto.MapTo<Tarea>();
                    entry.Created = DateTime.Now;
                }
                    
                DbSet<Tarea> dbset = ((ApplicationDbContext)Context).Tarea;

                // Codigo Generico..
                if (mode == "GET") entry = await dbset.SingleAsync(x => x.Id == id);
                if (mode == "DELETE" || mode == "PUT") entry = await dbset.AsTracking().SingleAsync(x => x.Id == id);
                if (mode == "POST") await dbset.AddAsync(entry);
                if (mode == "DELETE" && entry != null) Context.Remove(entry);
                if (mode == "PUT" && entry != null) dto.Transfer(ref entry);
                await Context.SaveChangesAsync();
                return entry;
            });
        }

    }
}