using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.StudyGroups.Commands.UpdateStudyGroup
{
    public class UpdateStudyGroupRoute
    {
        [FromRoute(Name = "id")]
        public int? Id { get; set; }
    }
}
