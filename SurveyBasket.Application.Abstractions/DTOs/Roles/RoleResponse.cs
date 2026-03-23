namespace SurveyBasket.Application.Abstractions.DTOs.Roles
{
    public record RoleResponse(
        string Id,
        string Name,
        bool IsDeleted
        );
}
