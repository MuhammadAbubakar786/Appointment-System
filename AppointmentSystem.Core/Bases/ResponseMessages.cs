namespace AppointmentSystem.Core.Bases
{
    public static class ResponseMessages
    {
        public static string Success { get; } = "Success";
        public static string Failure { get; } = "Fail";
        public static string Exception { get; } = "Exception";


        //Success Messages
        public const string CreatedSuccessfully = "record created successfully.";
        public const string UpdatedSuccessfully = "record updated successfully.";
        public const string DeletedSuccessfully = "record deleted successfully.";
        public const string RetrievedSuccessfully = "records retrieved successfully.";
        public const string OperationSuccessful = "Operation completed successfully.";
        public const string LoggedInSuccessfully = "User logged in successfully.";
        public const string RegisteredSuccessfully = "User registered successfully.";
        //2. Error Messages
        public const string AlreadyExists = "{0} already exists.";
        public const string NotFound = "{0} not found.";
        public const string OperationFailed = "An error occurred while processing {0}.";
        public const string InvalidInput = "Invalid input for {0}.";
        public const string UnauthorizedAccess = "You are not authorized to access {0}.";
        public const string ForbiddenAccess = "Access to {0} is forbidden.";
        public const string InvalidCredentials = "Invalid username or password.";
        public const string DuplicateRecord = "Duplicate record found for {0}.";
        public const string RecordInUse = "{0} cannot be deleted as it is in use.";
        public const string SomethingWentWrong = "something went wrong";
        //3. Information Messages
        public const string NoRecordsFound = "No records found";
        public const string PendingApproval = "{0} is pending approval.";
        public const string PasswordResetLinkSent = "A password reset link has been sent to your email.";
        public const string PasswordChangedSuccessfully = "Password changed successfully.";
        public const string TokenExpired = "The token for {0} has expired.";
        public const string SessionExpired = "Your session has expired. Please log in again.";
        public static string FormatMessage(string template, string entityName)
        {
            return string.Format(template, entityName);
        }
    }
}
