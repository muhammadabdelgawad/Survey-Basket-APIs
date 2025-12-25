using SurveyBasket.Application.Abstractions.DTOs.Polls.Requests;
using SurveyBasket.Application.Abstractions.DTOs.Polls.Responses;

namespace SurveyBasket.Application.Abstractions.Repositories.Polls
{
    public interface IPollService
    {
        Task<IEnumerable<PollResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<PollResponse>> GetCurrentAsync(CancellationToken cancellationToken = default);

        Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default);
        Task<Abstractions.Result> UpdateAsync(int id, PollRequest poll, CancellationToken cancellationToken = default);
        Task<Abstractions.Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<Abstractions.Result> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default);


    }
}
