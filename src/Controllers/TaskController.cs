using Microsoft.AspNetCore.Mvc;

using src.Context;

namespace src.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TaskController : ControllerBase
    {
        private readonly AgendaContext _context;

        public TaskController(AgendaContext context){
            _context = context;
        }

        [HttpGet("GetTask")]
        public IActionResult GetTask()
        {
            var TaskAgenda = _context.AgendaTasks.ToList();
            return Ok(TaskAgenda);
        }
    }
}