namespace SurveyBasket.Application.Abstractions.Repositories.Notification
{
    public interface INotificationService
    {
        Task SendNewNotificationAsync(int? pollId = null);
    }
}
