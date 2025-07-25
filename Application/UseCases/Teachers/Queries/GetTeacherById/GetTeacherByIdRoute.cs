using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Teachers.Queries.GetTeacherById
{
    public class GetTeacherByIdRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
