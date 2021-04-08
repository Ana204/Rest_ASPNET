using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMPLEMENTAÇÃO_VERBOS.Model;
using IMPLEMENTAÇÃO_VERBOS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rest_api01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
  
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        //listar todas as pessoas
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        //lista uma pessoa pelo id
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        //para adicionar uma nova pessoa
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest("Err !!");
            }
            return Ok(_personService.Create(person));
        }

        //para atualizar 
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if(person == null)
            {
                return BadRequest("Err !!");
            }
            return Ok(_personService.Update(person));
        }
        
        //para deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
