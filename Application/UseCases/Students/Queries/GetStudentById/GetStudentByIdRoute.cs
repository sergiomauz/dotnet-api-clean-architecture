using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Students.Queries.GetStudentById
{
    public class GetStudentByIdRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
