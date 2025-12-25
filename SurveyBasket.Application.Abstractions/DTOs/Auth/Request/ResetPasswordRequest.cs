namespace SurveyBasket.Application.Abstractions.DTOs.Auth.Request
{
   public record  ResetPasswordRequest
   (
       string Email,
         string ResetCode,
         string NewPassword
   );
    
}
