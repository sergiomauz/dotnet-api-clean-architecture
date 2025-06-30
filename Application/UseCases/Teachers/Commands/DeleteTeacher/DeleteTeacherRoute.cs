using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
