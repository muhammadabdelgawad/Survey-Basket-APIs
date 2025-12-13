namespace SurveyBasket.Application.Abstractions.DTOs.Results.Response
{
    public record VotesPerDayResponse
    (
       DateOnly Date,
       int NumberOfVotes
    );
}
