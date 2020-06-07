using System.Collections.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using USER.WebApi.DTOs;

namespace USER.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MainController : ControllerBase
    {
        public ActionResult CustomResponse(object obj = null)
        {
            if (obj is ResponseModel)
            {
                var resp = (ResponseModel)obj;
                if (!resp.Success)
                {
                    return BadRequest(new
                    {
                        success = resp.Success,
                        errorCode = resp.ErrorCode,
                        message = resp.Message
                    });
                }
                else
                {
                    return Ok(new { success = resp.Success, data = resp.Data, message = resp.Message });
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