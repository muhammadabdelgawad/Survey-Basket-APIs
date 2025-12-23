using SurveyBasket.Api.Helpers;
using SurveyBasket.Application.Abstractions.Repositories.Notification;
namespace SurveyBasket.Application.Services
{
    public class NotificationService(
        AppDbContext dbContext,
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        IEmailSender emailSender) : INotificationService
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IEmailSender _emailSender = emailSender;

        public async Task SendNewNotificationAsync(int? pollId = null)
        {
            IEnumerable<Poll> polls = [];

            if (pollId.HasValue)
            {
                var poll = await _dbContext.Polls.FirstOrDefaultAsync(x => x.Id == pollId && x.IsPublished);
                polls = [poll!];
            }
            else
            {
                polls = await _dbContext.Polls
                    .Where(x => x.IsPublished && x.StartsAt == DateOnly.FromDateTime(DateTime.UtcNow))
                    .AsNoTracking()
                    .ToListAsync();
            }

            var usere = await _userManager.Users.ToListAsync();

            var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin;

            foreach (var poll in polls)
            {
                foreach (var user in usere)
                {
                    var placeHolders=  new Dictionary<string, string>
                    {
                        { "{{name}}", user.FirstName},
                        { "{{pollTill}}", poll.Title},
                        { "{{endDate}}", poll.EndsAt.ToString()},
                        { "{{url}}",$"{origin}/polls/start/{poll.Id}" }
                    };

                    var body = EmailBodyBuilder.GenerateEmailBody("PollNotification", placeHolders);

                    await _emailSender.SendEmailAsync(user.Email!, $"📣 Survey Basket: New Poll - {poll.Title}", body);

                }
            }
        }
    }
}
