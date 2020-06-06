using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USER.WebApi.DTOs;
using static USER.WebApi.Domain.Enums;

namespace USER.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        public ActionResult CustomResponse(object obj = null)
        {
            if (obj == null)
            {
                return Ok(new { message = "Success!" });
            }

            if (obj is ResponseModel)
            {
                var resp = (ResponseModel)obj;
                //resp.Success
                if (resp.ErrorCode.HasValue)
                {
                    return BadRequest(new
                    {
                        errorCode = resp.ErrorCode,
                        message = resp.Message
                    });
                }
                else
                {
                    return Ok(new { resp.Data, message = resp.Message });
                }
                
            }

            if (obj is List<ValidationFailure>)
            {
                foreach (var item in (List<ValidationFailure>) obj)
                {
                    return BadRequest(new
                    {
                        message = item.ErrorMessage,
                        errorCode = item.ErrorCode
                    });
                }
                return BadRequest("Erro Inesperado");
            }

            return Ok();
        }
    }
}