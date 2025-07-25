using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.StudyGroups.Commands.UpdateStudyGroup
{
    public class UpdateStudyGroupRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
