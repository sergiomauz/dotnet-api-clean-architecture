using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.Schools.Commands.DeleteSchool
{
    public class DeleteSchoolRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
