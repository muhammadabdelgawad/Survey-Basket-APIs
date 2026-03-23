namespace SurveyBasket.Application.Abstractions.DTOs.Roles
{
    public record RoleDetailResponse(
       string Id,
       string Name,
       bool IsDeleted,
       IEnumerable<string> Permissions
       );
}
