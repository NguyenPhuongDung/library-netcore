
// using Library.Utilities.Constants;

// namespace Library.Models.Response
// {
//         public class LoginStatusResponse
//     {
//         public static LoginStatusResponse Failed => new LoginStatusResponse(LoginStatus.Failed, Messages.Api.Validation.Login.Failed);

//         public static LoginStatusResponse Success => new LoginStatusResponse(LoginStatus.Success);

//         public static LoginStatusResponse UnsupportedVersion => new LoginStatusResponse(LoginStatus.UnsupportedVersion, Messages.Api.Validation.Login.VersionIsNotSupported);

//         public static LoginStatusResponse NotAuthorized => new LoginStatusResponse(LoginStatus.NotAuthorized, Messages.Api.Validation.Login.NotAuthorized);

//         public static LoginStatusResponse Locked => new LoginStatusResponse(LoginStatus.UserLocked, Messages.Api.Validation.Login.Failed);

//         public static LoginStatusResponse RequiresTwoFactor => new LoginStatusResponse(LoginStatus.RequiresTwoFactor, Messages.Api.Validation.Login.RequiresTwoFactor);

//         public static LoginStatusResponse InvalidVerificationCode => new LoginStatusResponse(LoginStatus.Failed, Messages.Api.Validation.Login.InvalidVerificationCode);

//         public static LoginStatusResponse LockedTemporary(int lockedIntervalInMinutes)
//         {
//             return new LoginStatusResponse(LoginStatus.UserLockedTemporary, Messages.Api.Validation.Login.UserLocked(lockedIntervalInMinutes));
//         }

//         public LoginStatus Status { get; set; }

//         public string Message { get; set; }

//         public LoginStatusResponse(LoginStatus status)
//         {
//             Status = status;
//         }

//         public LoginStatusResponse(LoginStatus status, string message)
//             : this(status)
//         {
//             Message = message;
//         }
//     }
// }