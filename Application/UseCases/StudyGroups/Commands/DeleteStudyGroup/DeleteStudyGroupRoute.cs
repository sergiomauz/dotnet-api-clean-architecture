using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.StudyGroups.Commands.DeleteStudyGroup
{
    public class DeleteStudyGroupRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
