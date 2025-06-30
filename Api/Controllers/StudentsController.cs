using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Students.Commands.CreateStudent;
//using Application.UseCases.Students.Commands.DeleteStudent;
//using Application.UseCases.Students.Commands.UpdateStudent;


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
    }
}
