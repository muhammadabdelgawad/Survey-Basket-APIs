using SurveyBasket.Application.Abstractions.DTOs.Results.Response;

namespace SurveyBasket.Application.Abstractions.Repositories.Result
{
    public interface IResultService
    {
        Task<Result<PollVotesResponse>> GetPollVotesAsync(int pollId, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<VotesPerDayResponse>>> GetVotesPerDayAsync(int pollId, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<VotesPerQuestionResponse>>> GetVotesPerQuestionAsync(int pollId, CancellationToken cancellationToken = default);

    }
}
