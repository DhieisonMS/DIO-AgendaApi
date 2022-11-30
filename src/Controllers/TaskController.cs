using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading;
using src.entities;
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

        [HttpGet("tasks")]
        public IActionResult GetTask()
        {
            var TaskAgenda = _context.AgendaTasks.ToList();

            if(TaskAgenda.Count == 0){
                return NotFound();
            }
            return Ok(TaskAgenda);
        }

        [HttpGet("tasks/{id}")]
        public IActionResult GetTaskID(int id)
        {
            var taskAgenda = _context.AgendaTasks.Find(id);

            if(taskAgenda == null){
                return NotFound();
            }
            return Ok(taskAgenda);
        }

        [HttpPost("tasks/new")]
        public IActionResult PostNewTask(string name, string description)
        {

            AgendaTask NewTask = new AgendaTask();

            var culture = new System.Globalization.CultureInfo("pt-BR");
            var targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");

            var targetDAteTime = TimeZoneInfo.ConvertTime(DateTime.Now, targetTimeZone);
            string date = targetDAteTime.ToString("dd/MM/yyyy HH:mm:ss tt");
            var value = DateTime.Parse(date, culture);

            
            NewTask.Name = name;
            NewTask.Description = description;
            NewTask.Date = value;
            _context.Add(NewTask);
            _context.SaveChanges();

            return Ok(NewTask);          

        }
        
        [HttpDelete("tasks/{id}")]
        public IActionResult DeleteTask(int id)
        {

            var taskid = _context.AgendaTasks.Find(id);

            if (taskid == null){
                return NotFound();
            }
            _context.AgendaTasks.Remove(taskid);
            _context.SaveChanges();
            return Ok(taskid);
        }

        [HttpPut("tasks/{id}")]
        public IActionResult UpdateTask(int id, AgendaTask taskAgenda)
        {
            var taskid = _context.AgendaTasks.Find(id);
            if (taskid == null){
                return NotFound();
            }

            taskid.Name = taskAgenda.Name;
            taskid.Description = taskAgenda.Description;
            taskid.Complete = taskAgenda.Complete;
        
           
            _context.SaveChanges();

            return Ok(taskid);
            
            return Ok();
        }
   
    }
}