using Microsoft.AspNetCore.Mvc;
using Strojevi.Interfaces;
using Strojevi.Models;
using System.Collections.Generic;

namespace Strojevi.Controller
{
    [ApiController]
    [Route("api/statusi")]
    public class StatusController : ControllerBase
    {
        private readonly IStatus _statusRepository;
        public StatusController(IStatus status)
        {
            _statusRepository = status;
        }
        [HttpGet]
        public IEnumerable<Status> GetAll()
        {
            return _statusRepository.GetAll();
        }
    }
}
