namespace SurveyBasket.Application.Abstractions.DTOs.Results.Response
{
    public record VotesPerQuestionResponse
    (
        string Question,
        IEnumerable<VotesPerAnswerResponse> SelectedAnswers
    );
}
