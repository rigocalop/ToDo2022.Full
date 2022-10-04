using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ToDo2022.Api.Controllers
{
    public partial class TareaController : ControllerBase, IEzControllerBase
    {
        [HttpPut("DeleteBySelection")]
        public async Task<ActionResult<int>> DeleteBySelectionAsync(string Meta_Id)
        {
            string sQryDelete = $"DELETE FROM TODO.TAREA WHERE IsSelected=1 AND Meta_Id={Meta_Id}";
            int iRowsAffected =await Context.Database.ExecuteSqlRawAsync(sQryDelete);
            return Ok(iRowsAffected);
        }
        [HttpPut("CompleteBySelection")]
        public async Task<ActionResult<int>> CompleteBySelectionAsync(string Meta_Id)
        {
            string sQryUpdate = $"UPDATE TODO.TAREA SET IsCompleted=1 WHERE IsSelected = 1 AND Meta_Id={Meta_Id}";
            int iRowsAffected = await Context.Database.ExecuteSqlRawAsync(sQryUpdate);
            return Ok(iRowsAffected);
        }
        [HttpPut("BySelection")]
        public async Task<ActionResult<int>> CompleteBySelectionAsync(string Meta_Id, string mode)
        {
            string sQryToExecute = "";
            switch(mode.ToUpper())
            {
                case "SELECTEDALL": 
                    sQryToExecute = $"UPDATE TODO.TAREA SET IsSelected=1 WHERE Meta_Id={Meta_Id}";
                    break;
                case "UNSELECTEDALL":
                    sQryToExecute = $"UPDATE TODO.TAREA SET IsSelected=0 WHERE Meta_Id={Meta_Id}";
                    break;
                case "COMPLETE":
                    sQryToExecute = $"UPDATE TODO.TAREA SET IsCompleted=1 WHERE IsSelected = 1 AND Meta_Id={Meta_Id}";
                    break;
                case "DELETE":
                    sQryToExecute = $"DELETE FROM TODO.TAREA WHERE IsSelected=1 AND Meta_Id={Meta_Id}";
                    break;

            }
            int iRowsAffected = await Context.Database.ExecuteSqlRawAsync(sQryToExecute);
            return Ok(iRowsAffected);
        }
    }
}