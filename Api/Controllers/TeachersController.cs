using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Teachers.Commands.CreateTeacher;
using Application.UseCases.Teachers.Commands.DeleteTeacher;
using Application.UseCases.Teachers.Commands.UpdateTeacher;
using Application.UseCases.Teachers.Queries.GetTeacherById;
using Application.UseCases.Teachers.Queries.GetTeacherByCode;


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
        public async Task<ActionResult<DeleteTeacherVm>> DeleteTeacher([FromRoute] DeleteTeacherRoute route)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTeacherByIdVm>> GetTeacherById([FromRoute] GetTeacherByIdRoute route)
        {
            var query = Mapper.Map<GetTeacherByIdQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("get-by-code/{code}")]
        public async Task<ActionResult<GetTeacherByCodeVm>> GetTeacherByCode([FromRoute] GetTeacherByCodeRoute route)
        {
            var query = Mapper.Map<GetTeacherByCodeQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
