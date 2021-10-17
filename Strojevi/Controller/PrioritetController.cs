using Microsoft.AspNetCore.Mvc;
using Strojevi.Interfaces;
using Strojevi.Models;
using System.Collections.Generic;

namespace Strojevi.Controller
{
    [ApiController]
    [Route("api/prioriteti")]
    public class PrioritetController : ControllerBase
    {

        private readonly IPrioritet _prioritetRepository;
        public PrioritetController(IPrioritet prioritet)
        {
            _prioritetRepository = prioritet;
        }
        [HttpGet]
        public IEnumerable<Prioritet> GetAll()
        {
            return _prioritetRepository.GetAll();
        }
    }
}
