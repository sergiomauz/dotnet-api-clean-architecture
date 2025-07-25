using Microsoft.AspNetCore.Mvc;


namespace Application.UseCases.StudyGroups.Queries.GetStudyGroupByCode
{
    public class GetStudyGroupByCodeRoute
    {
        [FromRoute(Name = "code")]
        public string? Code { get; set; }
    }
}
