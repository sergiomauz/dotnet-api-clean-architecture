using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Courses.Commands.CreateCourse;
using Application.UseCases.Courses.Commands.DeleteCourse;
using Application.UseCases.Courses.Commands.UpdateCourse;
using Application.UseCases.Courses.Queries.GetCourseById;
using Application.UseCases.Courses.Queries.GetCourseByCode;


namespace Api.Controllers
{
    [Route("api/courses")]
    public class CoursesController : CustomControllerBase
    {
        [HttpPost("")]
        public async Task<ActionResult<CreateCourseVm>> CreateCourse([FromBody] CreateCourseDto body)
        {
            var command = Mapper.Map<CreateCourseCommand>(body);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCourseVm>> DeleteCourse([FromRoute] DeleteCourseRoute route)
        {
            var command = Mapper.Map<DeleteCourseCommand>(route);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCourseVm>> UpdateCourse([FromRoute] UpdateCourseRoute route, [FromBody] UpdateCourseDto body)
        {
            var command = Mapper.Map<UpdateCourseCommand>(route);
            Mapper.Map(body, command);
            Mapper.Map(Request, command);

            var vm = await Mediator.Send(command);

            return Ok(vm);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetCourseByIdVm>> GetCourseById([FromRoute] GetCourseByIdRoute route)
        {
            var query = Mapper.Map<GetCourseByIdQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("get-by-code/{code}")]
        public async Task<ActionResult<GetCourseByCodeVm>> GetCourseByCode([FromRoute] GetCourseByCodeRoute route)
        {
            var query = Mapper.Map<GetCourseByCodeQuery>(route);
            Mapper.Map(Request, query);

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
