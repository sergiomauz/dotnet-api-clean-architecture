using Microsoft.AspNetCore.Mvc;
using Application.Commons.VMs;
using Application.UseCases.Enrollments.Commands.CreateEnrollment;
using Application.UseCases.Enrollments.Commands.DeleteEnrollment;
//using Application.UseCases.Teachers.Commands.UpdateTeacher;


namespace Api.Controllers
{
    [Route("api/enrollments")]
    public class EnrollmentsController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateEnrollmentVm>> CreateEnrollment([FromBody] CreateEnrollmentDto body)
        {
            var command = Mapper.Map<CreateEnrollmentCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WereDeletedVm>> DeleteEnrollment([FromRoute] DeleteEnrollmentRoute route)
        {
            var command = Mapper.Map<DeleteEnrollmentCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }
    }
}
