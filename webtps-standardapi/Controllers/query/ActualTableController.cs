using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using webtps_standardapi.Models;

namespace webtps_standardapi.Controllers.query
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualTableController : ControllerBase
    {

        #region Connection String
        private readonly SqlConnection tpscon = new SqlConnection(@"
            Data Source=JUNELPC\SQLEXPRESS;Initial Catalog=Web_TPS;Integrated Security=True;Encrypt=False");
        #endregion

        [HttpGet("TPSREPORT")]
        public IActionResult getTpsReport()
        {
            var result = tpscon.Query(@"
                SELECT * FROM [TYPE_TABLE] 
                INNER JOIN [TPS_TABLE] 
                ON [TPS_TABLE].TPS_ID 
                = [TYPE_TABLE].TPS_ID")
            ?.ToList();
            return Ok(result);
        }

        [HttpGet("TYPEDATA")]
        public IActionResult getSubtypeData(string type)
        {
            var result = tpscon.Query(@"
                SELECT DISTINCT DATA_ID, 
                SUBT_NAME, DATA_VAL, 
                DATE_MD, TYPE_NAME 
                FROM [DATA_TABLE]	 
                INNER JOIN [SUBTYPE_TABLE] 
                ON [SUBTYPE_TABLE].SUBT_ID 
                = [DATA_TABLE].SUBT_ID 
                INNER JOIN [TYPE_TABLE] 
                ON [SUBTYPE_TABLE].TYPE_ID 
                = [TYPE_TABLE].TYPE_ID WHERE TYPE_NAME 
                = @type", new
                    {
                        type = type
                    }
                )
            ?.ToList();
            return Ok(result);
        }
    }
}
