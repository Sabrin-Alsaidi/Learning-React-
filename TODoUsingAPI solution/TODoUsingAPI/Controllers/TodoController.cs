using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TODoUsingAPI.Context;
using TODoUsingAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TODoUsingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get All
        [HttpGet]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]

        public ActionResult GetAll()
        {
            var todos = _context.todo.ToList();
            if (todos.Count > 0)
            {
                return Ok(todos);
            }
            return BadRequest();
        }

        //Get Details
        [HttpGet("int:id")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        public ActionResult Get(int id)
        {
            var todos = _context.todo.Find(id);
            if (todos is null)
            {
                return BadRequest();
            }
            return Ok(todos);

        }

        //Create new
        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.todo.Add(todo);
                _context.SaveChanges();
                return Ok(todo);

            }
            return BadRequest();
        }

        //Update 
        [HttpPut("int : id")]
        public ActionResult Update(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.todo.Update(todo);
                _context.SaveChanges();
                return Ok(todo);

            }
            return BadRequest();
        }

        //Delete
        [HttpDelete("int id")]
        public ActionResult Delete(Todo todo)
        {
            _context.Set<Todo>().Remove(todo);
            _context.SaveChanges();
            return Ok(_context.todo.ToList());

        }
    }
}

