using Microsoft.AspNetCore.Mvc;
using Application.Commons.VMs;
using Application.UseCases.StudyGroups.Commands.CreateStudyGroup;
using Application.UseCases.StudyGroups.Commands.DeleteStudyGroup;
//using Application.UseCases.Teachers.Commands.UpdateTeacher;


namespace Api.Controllers
{
    [Route("api/study-groups")]
    public class StudyGroupsController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateStudyGroupVm>> CreateStudyGroup([FromBody] CreateStudyGroupDto body)
        {
            var command = Mapper.Map<CreateStudyGroupCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WereDeletedVm>> DeleteStudyGroup([FromRoute] DeleteStudyGroupRoute route)
        {
            var command = Mapper.Map<DeleteStudyGroupCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }
    }
}
