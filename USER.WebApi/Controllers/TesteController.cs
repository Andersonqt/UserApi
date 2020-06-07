using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace USER.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TesteController : ControllerBase
    {
        // GET: api/Teste
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Api online");
        }
    }
}
