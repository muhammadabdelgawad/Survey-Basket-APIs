using SurveyBasket.Application.Abstractions.DTOs.Votes.Request;

namespace SurveyBasket.Application.Abstractions.Repositories.Vote
{
    public interface IVoteService
    {
        Task<Abstractions.Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default);
    }
}
