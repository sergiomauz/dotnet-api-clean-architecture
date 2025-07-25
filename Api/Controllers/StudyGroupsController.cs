using Microsoft.AspNetCore.Mvc;
using Application.UseCases.StudyGroups.Commands.CreateStudyGroup;
using Application.UseCases.StudyGroups.Commands.DeleteStudyGroup;
using Application.UseCases.StudyGroups.Commands.UpdateStudyGroup;
using Application.UseCases.StudyGroups.Queries.GetStudyGroupById;
using Application.UseCases.StudyGroups.Queries.GetStudyGroupByCode;


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
        public async Task<ActionResult<UpdateStudyGroupVm>> UpdateStudyGroup([FromRoute] UpdateStudyGroupRoute route, [FromBody] UpdateStudyGroupDto body)
        {
            var command = Mapper.Map<UpdateStudyGroupCommand>(route);
            Mapper.Map(body, command);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudyGroupByIdVm>> GetStudyGroupById([FromRoute] GetStudyGroupByIdRoute route)
        {
            var query = Mapper.Map<GetStudyGroupByIdQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("get-by-code/{code}")]
        public async Task<ActionResult<GetStudyGroupByCodeVm>> GetStudyGroupByCode([FromRoute] GetStudyGroupByCodeRoute route)
        {
            var query = Mapper.Map<GetStudyGroupByCodeQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
