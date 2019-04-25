using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InDev.Models;
using InDev.DbModels;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InDev.Configuration;
using System.Collections.Generic;

namespace InDev.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDos")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PostgresContext _context;

        public ToDoController(IMapper mapper, PostgresContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody]ApiToDo toDo)
        {
            var entity = _mapper.Map<DalToDo>(toDo);
            var result = _context.Add(entity);
            _context.SaveChanges(true);
            return Ok(_mapper.Map<ApiToDo>(result.Entity));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var toDo = _context.ToDos
                .FirstOrDefault(x => x.Id == id);

            if (toDo == null) return NotFound(id);
            return Ok(_mapper.Map<ApiToDo>(toDo));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var toDos = _context.ToDos
                .Select(_mapper.Map<ApiToDo>)
                .ToList();
            return Ok(toDos);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ApiToDo toDo)
        {
            var entity = _mapper.Map<DalToDo>(toDo);
            entity.Id = id;
            var originToDo = _context.ToDos.FirstOrDefault(x => x.Id == toDo.Id);
            _context.Entry(originToDo).State = EntityState.Detached;

            entity.Id = originToDo.Id;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges(true);
            return Ok(Get(toDo.Id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = new DalToDo { Id = id };
            var entity = _context.ToDos.Remove(todo);
            bool result = true;
            if (entity == null)
            {
                result = false;
            }
            _context.SaveChanges();
            
            return Ok(result);
        }
    }
}
