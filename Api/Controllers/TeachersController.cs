using Application.Commons.VMs;
using Application.UseCases.Teachers.Commands.CreateTeacher;
using Application.UseCases.Teachers.Commands.DeleteTeacher;
using Application.UseCases.Teachers.Commands.UpdateTeacher;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/teachers")]
    public class TeachersController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateTeacherVm>> CreateTeacher([FromBody] CreateTeacherDto body)
        {
            var command = Mapper.Map<CreateTeacherCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WereDeletedVm>> DeleteTeacher([FromRoute] DeleteTeacherRoute route)
        {
            var command = Mapper.Map<DeleteTeacherCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTeacherVm>> UpdateTeacher([FromRoute] UpdateTeacherRoute route, [FromBody] UpdateTeacherDto body)
        {
            var command = Mapper.Map<UpdateTeacherCommand>(route);
            Mapper.Map(body, command);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }
    }
}
