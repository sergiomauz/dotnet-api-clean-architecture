using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.StudyGroups.Queries.GetStudyGroupById
{
    public class GetStudyGroupByIdRoute
    {
        [FromRoute(Name = "id")]
        public string? Id { get; set; }
    }
}
