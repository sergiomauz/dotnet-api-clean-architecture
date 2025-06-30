using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Teachers.Commands.CreateTeacher;


namespace Api.Controllers
{
    [Route("api/teachers")]
    public class TeachersController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateTeacherVm>> CreateCompany([FromBody] CreateTeacherDto body)
        {
            var command = Mapper.Map<CreateTeacherCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }
    }
}
