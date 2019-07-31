namespace Library.Utilities.Dictionaries
{
    public enum LoginStatus
    {
        Success = 0,
        Failed = 1,
        UserLocked = 2,
        UserLockedTemporary = 3,
        UnsupportedVersion = 4,
        NotAuthorized = 5,
        RequiresTwoFactor = 6,
    }
}