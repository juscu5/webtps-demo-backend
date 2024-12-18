using Dapper;
using webtps_standardapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace webtps_standardapi.Controllers.query
{
    [Route("api/[controller]")]
    [ApiController]
    public class TpsTableController : ControllerBase
    {
        #region Connnection String
        private readonly SqlConnection tpscon = new SqlConnection(@"
            Data Source=JUNELPC\SQLEXPRESS;Initial Catalog=Web_TPS;Integrated Security=True;Encrypt=False");
        #endregion

        [HttpGet("TPS")]
        public IActionResult GetTps()
        {
            var result = tpscon.Query<TpsModel>(@"SELECT * FROM [TPS_TABLE]")?.ToList();
            return Ok(result);
        }

        [HttpGet("TYPE")]
        public new IActionResult GetType()
        {
            var result = tpscon.Query<TypeModel>(@"SELECT * FROM [TYPE_TABLE]")?.ToList();
            return Ok(result);
        }

        [HttpGet("SUBTYPE")]
        public IActionResult GetSubtype()
        {
            var result = tpscon.Query<SubtypeModel>(@"SELECT * FROM [SUBTYPE_TABLE]")?.ToList();
            return Ok(result);
        }

        [HttpGet("DATA")]
        public IActionResult GetData()
        {
            var result = tpscon.Query<DataModel>(@"SELECT * FROM [DATA_TABLE]")?.ToList();
            return Ok(result);
        }
    }
}
