using Microsoft.AspNetCore.Mvc;
using RedisOM.Entity;
using RedisOM.Repository;

namespace WebApplicationRedis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoseController : ControllerBase
    {
        IRepository<RoseEntity> repository;
        public RoseController(IRepository<RoseEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoseEntity entity)
        {
            var result = await repository.Save(entity);
            
            return Ok(result);
        }
    }
}
