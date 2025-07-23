using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.StudyGroups.Commands.DeleteSchool
{
    public class DeleteSchoolRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
