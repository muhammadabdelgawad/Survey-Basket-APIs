namespace SurveyBasket.Application.Abstractions.DTOs.Results.Response
{
    public record VoteResponse
    (
        string VoterName,
        DateTime VotedDate,
        IEnumerable<QuestionAnswerResponse> SelectedAnswers
    );
}
