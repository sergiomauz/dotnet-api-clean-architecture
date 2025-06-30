using Microsoft.AspNetCore.Mvc;
using Application.Commons.VMs;
using Application.UseCases.Schools.Commands.CreateSchool;
using Application.UseCases.Schools.Commands.DeleteSchool;
//using Application.UseCases.Teachers.Commands.UpdateTeacher;


namespace Api.Controllers
{
    [Route("api/schools")]
    public class SchoolsController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateSchoolVm>> CreateSchool([FromBody] CreateSchoolDto body)
        {
            var command = Mapper.Map<CreateSchoolCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WereDeletedVm>> DeleteSchool([FromRoute] DeleteSchoolRoute route)
        {
            var command = Mapper.Map<DeleteSchoolCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }
    }
}
