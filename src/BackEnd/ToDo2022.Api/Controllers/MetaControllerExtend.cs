using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ToDo2022.Api.Controllers
{
    public partial class MetaController : ControllerBase, IEzControllerBase
    {
        /// <summary>
        /// Actualiza campos de calculados con en fin de ahorrar tiempo en las consultas anidadas...
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Refresh/{id}")]
        public async Task<ActionResult<object>> PutRefreshAsync(int id, string? mode ="")
        {
            if (mode == null) mode = "";
            switch (mode)
            {
                case "REFRESH":
                default:
                    //PARTE 1. OBTENCION DEL TOTAL DE LOS ELEMENTOS.
                    
                    string sQryTotalItems = @"SELECT * FROM TODO.TAREA WHERE META_ID = <#META_ID>";
                    sQryTotalItems = sQryTotalItems.Replace("<#META_ID>", id.ToString());
                    int iTotalItems = (((ApplicationDbContext)Context).Tarea).FromSqlRaw(sQryTotalItems).Count();


                    string sQryTotalCompleted = @"SELECT * FROM TODO.TAREA WHERE ISCOMPLETED=1 AND META_ID = <#META_ID>";
                    sQryTotalCompleted = sQryTotalCompleted.Replace("<#META_ID>", id.ToString());
                    int iTotalItemsCompleted = (((ApplicationDbContext)Context).Tarea).FromSqlRaw(sQryTotalCompleted).Count();

                    string sQryTotalSelected = @"SELECT * FROM TODO.TAREA WHERE ISSELECTED=1 AND META_ID = <#META_ID>";
                    sQryTotalSelected = sQryTotalSelected.Replace("<#META_ID>", id.ToString());
                    int iTotalItemsSelected = (((ApplicationDbContext)Context).Tarea).FromSqlRaw(sQryTotalSelected).Count();


                    int iPorcentajeTareasCompleted = 0;
                    if (iTotalItemsCompleted > 0) iPorcentajeTareasCompleted = (int)(100 * (decimal)((decimal)iTotalItemsCompleted / (decimal)iTotalItems));

                    string sQryUpdate = "UPDATE TODO.META set PorcentajeTareasCompleted = <#PORCENTAJETAREASCOMPLETED>, TotalTareas = <#TOTALTAREAS>, TotalTareasCompleted = <#TOTALTAREASCOMPLETED>, TotalTareasSelected = <#TOTALTAREASSELECTED> WHERE ID = <#META_ID>";

                    sQryUpdate = sQryUpdate.Replace("<#META_ID>", id.ToString());
                    sQryUpdate = sQryUpdate.Replace("<#PORCENTAJETAREASCOMPLETED>", iPorcentajeTareasCompleted.ToString());
                    sQryUpdate = sQryUpdate.Replace("<#TOTALTAREAS>", iTotalItems.ToString());
                    sQryUpdate = sQryUpdate.Replace("<#TOTALTAREASCOMPLETED>", iTotalItemsCompleted.ToString());
                    sQryUpdate = sQryUpdate.Replace("<#TOTALTAREASSELECTED>", iTotalItemsSelected.ToString());
                    int rowsAffected = await Context.Database.ExecuteSqlRawAsync(sQryUpdate);

                    return this.Ok(rowsAffected);
            }
            return Ok();
        }
    }
}