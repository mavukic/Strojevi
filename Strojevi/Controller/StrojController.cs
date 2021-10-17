using Microsoft.AspNetCore.Mvc;
using Strojevi.Models;
using Strojevi.Interfaces;
using System.Collections.Generic;
using System;

namespace Strojevi.Controller
{
    [ApiController]
    [Route("api/strojevi")]
    public class StrojController : ControllerBase
    {
        private readonly IStroj _strojRepository;
        public StrojController(IStroj stroj)
        {
            _strojRepository = stroj;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Stroj stroj)
        {
            
            if (ModelState.IsValid)
            {
_strojRepository.Dodaj(stroj);
                return Ok(stroj);
            }
            else
            {
                return BadRequest();
            }
             
        }
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _strojRepository.Delete(id);



        }
        [HttpGet]
        public IEnumerable<Stroj> GetAll()
        {
            return _strojRepository.GetAll();
        }
        
        [HttpGet("[action]")]
        public IEnumerable<Kvar> GetKvarovi()
        {
            return _strojRepository.GetKvarovi();
        }
        [HttpGet("{id:int}")]
        public IEnumerable<Stroj> Get(int id)
        {

            return _strojRepository.Get(id);


        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Stroj stroj)
        {
            try
            {
                var dbCompany = _strojRepository.Get(id);
                if (dbCompany == null)
                    return NotFound();
                _strojRepository.Update(id, stroj);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
