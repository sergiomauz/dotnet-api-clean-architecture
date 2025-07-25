using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Students.Commands.CreateStudent;
using Application.UseCases.Students.Commands.DeleteStudent;
using Application.UseCases.Students.Commands.UpdateStudent;
using Application.UseCases.Students.Queries.GetStudentById;
using Application.UseCases.Students.Queries.GetStudentByCode;


namespace Api.Controllers
{
    [Route("api/students")]
    public class StudentsController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateStudentVm>> CreateStudent([FromBody] CreateStudentDto body)
        {
            var command = Mapper.Map<CreateStudentCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteStudentVm>> DeleteStudent([FromRoute] DeleteStudentRoute route)
        {
            var command = Mapper.Map<DeleteStudentCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateStudentVm>> UpdateStudent([FromRoute] UpdateStudentRoute route, [FromBody] UpdateStudentDto body)
        {
            var command = Mapper.Map<UpdateStudentCommand>(route);
            Mapper.Map(body, command);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentByIdVm>> GetStudentById([FromRoute] GetStudentByIdRoute route)
        {
            var query = Mapper.Map<GetStudentByIdQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("get-by-code/{code}")]
        public async Task<ActionResult<GetStudentByCodeVm>> GetStudentByCode([FromRoute] GetStudentByCodeRoute route)
        {
            var query = Mapper.Map<GetStudentByCodeQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
