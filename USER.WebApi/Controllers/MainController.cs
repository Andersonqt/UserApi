using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static USER.WebApi.Domain.Enums;

namespace USER.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        //public ActionResult CustomResponse(List<ValidationFailure> errors)
        //{
        //    foreach (var item in errors)
        //    {
        //        return BadRequest(new
        //        {
        //            message = ((ErrorCode)Enum.Parse(typeof(ErrorCode), item.ErrorCode)).GetEnumDescription(),
        //            errorCode = item.ErrorCode
        //        });
        //    }
        //    return BadRequest("Erro Inesperado");
        //}

        public ActionResult CustomResponse(object obj = null)
        {
            if (obj == null)
            {
                return Ok(new { message = "Success!" });
            }

            if (obj is List<ValidationFailure>)
            {
                foreach (var item in (List<ValidationFailure>) obj)
                {
                    return BadRequest(new
                    {
                        message = ((ErrorCode)Enum.Parse(typeof(ErrorCode), item.ErrorCode)).GetEnumDescription(),
                        errorCode = item.ErrorCode
                    });
                }
                return BadRequest("Erro Inesperado");
            }

            return Ok();
        }
    }
}