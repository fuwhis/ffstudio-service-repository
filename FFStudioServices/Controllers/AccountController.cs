using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace FFStudioServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //string query = @"
            //    select uid as ""UserId"",
            //        user_name as ""Username""
            //    from accounts
            //";

            string query = @"select * from accounts";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("2fStudioDB");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myConn = new NpgsqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            Console.Write(table);
            return new JsonResult(table);
        }
    }
}
