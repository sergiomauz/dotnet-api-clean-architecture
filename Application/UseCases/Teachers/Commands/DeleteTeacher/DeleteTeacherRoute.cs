using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
