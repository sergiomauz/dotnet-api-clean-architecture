using Microsoft.AspNetCore.Mvc;
using Application.UseCases.StudyGroups.Commands.CreateStudyGroup;
using Application.UseCases.StudyGroups.Commands.DeleteStudyGroup;
using Application.UseCases.StudyGroups.Commands.UpdateStudyGroup;


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
        public async Task<ActionResult<DeleteStudyGroupVm>> DeleteStudyGroup([FromRoute] DeleteStudyGroupRoute route)
        {
            var command = Mapper.Map<DeleteStudyGroupCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateStudyGroupVm>> UpdateTeacher([FromRoute] UpdateStudyGroupRoute route, [FromBody] UpdateStudyGroupDto body)
        {
            var command = Mapper.Map<UpdateStudyGroupCommand>(route);
            Mapper.Map(body, command);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }
    }
}
