namespace SurveyBasket.Application.Abstractions.DTOs.Results.Response
{
    public record PollVotesResponse
    (
        string Title,
        IEnumerable<VoteResponse> Votes
    );

}
