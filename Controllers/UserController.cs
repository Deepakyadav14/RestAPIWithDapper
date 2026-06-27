using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace RestFul_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDbConnectionFactory _dbFactory;
        public UserController(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        [HttpGet("/GetProjects")]
       public async Task<IActionResult> GetPorjectList()
       {
            using var connection = _dbFactory.CreateConnection();
            string sql = "SELECT TOP (100) [Id],[Title],[Subtitle],[Description],[Sector],[City],[FeaturesJson] FROM [AyansVillas].[dbo].[Projects]";
            var data =await connection.QueryAsync<ProjectsDetails>(sql);
            return Ok(data);
                
       }
    }
    
    public class ProjectsDetails
    {
       public int Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string?  Description { get; set; }
        public string? Sector { get; set; }
        public string? City { get; set; }
        public string[]? FeaturedJson { get; set; }

    }

}
