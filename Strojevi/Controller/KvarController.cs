using Microsoft.AspNetCore.Mvc;
using Strojevi.Interfaces;
using Strojevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Strojevi.Controller
{
    [ApiController]
    [Route("api/kvarovi")]
    public class KvarController : ControllerBase
    {
        private readonly IKvar _kvarRepository;
        public KvarController(IKvar kvar)
        {
            _kvarRepository = kvar;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Kvar kvar)
        {

            if (ModelState.IsValid)
            {
                _kvarRepository.Dodaj(kvar);
                return Ok(kvar);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IEnumerable<Kvar> GetAll()
        {
            var kvarovi= _kvarRepository.GetAll();
            kvarovi.OrderBy(x =>
  x.prioritet == "Visok" ? 1 :
  x.prioritet == "Srednji" ? 2 :
  3)
  .ThenByDescending(y=>y.VrijemePocetka);
            return kvarovi;
        }
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
          _kvarRepository.Delete(id);
         
           

    }
        [HttpGet("{id:int}")]
        public IEnumerable<Kvar> Get(int id)
        {
            
               return _kvarRepository.Get(id);

           
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Kvar kvar)
        {
            try
            {
                var dbCompany = _kvarRepository.Get(id);
                if (dbCompany == null)
                    return NotFound();
                _kvarRepository.Update(id, kvar);
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
