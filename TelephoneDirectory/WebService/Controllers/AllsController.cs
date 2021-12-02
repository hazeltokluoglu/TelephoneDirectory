using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Data.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllsController : ControllerBase
    {
        private readonly IAllRepository _allRepository;

        public AllsController(IAllRepository allRepository)
        {
            _allRepository = allRepository;
        }

        // GET: api/Alls
        [HttpGet]
        public IEnumerable<AllList> Get()
        {
            return _allRepository.GetAll();
        }
    }
}
