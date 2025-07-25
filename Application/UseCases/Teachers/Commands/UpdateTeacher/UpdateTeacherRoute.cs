using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
