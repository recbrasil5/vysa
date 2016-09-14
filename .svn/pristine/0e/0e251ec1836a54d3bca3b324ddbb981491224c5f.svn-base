namespace VYSA.WebApi.Services
{
    public class ExceptionLogService
    {
        //public const Int16 MaxExceptionCount = 1000;
        //private UnitOfWork unitOfWork;
        //public ExceptionLogService(IUnitOfWork _unitOfWork)
        //{
        //    this.unitOfWork = (UnitOfWork)_unitOfWork;
        //}

        //public int LogError(Exception ex, string additionalInfo, Boolean saveToDatabase, Boolean emailAdminNotification, int? userId, string userName)
        //{
        //    var sqlErrorSb = new StringBuilder();

        //    DateTime timestamp = DateTime.Now.ToUniversalTime();
        //    String source = !String.IsNullOrEmpty(ex.Source) ? ex.Source : "";
        //    String target = !String.IsNullOrEmpty(ex.TargetSite.Name) ? ex.TargetSite.Name : "";
        //    String exceptionType = ex.GetType().ToString();
        //    String message = ex.Message.Replace("Pangea", "The System");// Nice work Bryant!
        //    String stackTrace = ex.StackTrace;
        //    HttpContext context = HttpContext.Current;
        //    String requestIp = context.Request.UserHostAddress;
        //    String requestUrl = context.Request.Url.AbsoluteUri;
        //    int exceptionId = -1;

        //    var sqlException = ex as SqlException;
        //    if (sqlException != null)
        //    {
        //        foreach (SqlError error in sqlException.Errors)
        //            sqlErrorSb.AppendLine(String.Format("SqlError: {0}", error));
        //    }

        //    #region Save to DB
        //    if (saveToDatabase)
        //    {
        //        //build the Entity
        //        var el = new ExceptionLog
        //        {
        //            AccountUserId = userId, 
        //            Domain = GetDomain(requestUrl), 
        //            Request_IP = requestIp, 
        //            Request_URL = requestUrl, 
        //            ExceptionType = exceptionType, 
        //            TargetSite = target, 
        //            Message = message, 
        //            Source = source, 
        //            StackTrace = stackTrace, 
        //            AdditionalInfo = additionalInfo, 
        //            AdditionalInfoSQLError = "", 
        //            TimestampUtc = timestamp
        //        };

        //        _exceptionRepository.Add(el);
        //        _exceptionRepository.Save();
        //        _exceptionRepository.Entities.Entry(el).Reference(l => l.AccountUser).Load();

        //        exceptionId= el.Id;
        //    }
        //    #endregion

        //    #region Email Exception
        //    if (emailAdminNotification)
        //    {
        //        try
        //        {
        //            StringBuilder emailMsgBody = new StringBuilder();
        //            emailMsgBody.AppendFormat("ExceptionLogId: {0}", exceptionId);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Server Date/Time: {0}", timestamp.ToString("MM/dd/yyyy HH:mm:ss"));
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Request from IP: {0}", requestIp);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Request URL: {0}", requestUrl);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Client still connected: {0}", context.Response.IsClientConnected);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Username: {0}", userName);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Account User ID: {0}", userId);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Exception Type: {0}", exceptionType);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Message: {0}", message);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Source: {0}", source);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("StackTrace: {0}", stackTrace);
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendLine();
        //            emailMsgBody.AppendFormat("Additional Info: {0}", additionalInfo);
        //            emailMsgBody.AppendLine();

        //            if (ex is SqlException)
        //            {
        //                emailMsgBody.AppendFormat("{0}", sqlErrorSb);
        //                emailMsgBody.AppendLine();
        //            }
        //            Providers.EmailProvider.SendEmail(new MailAddress(Settings.Default.ErrorEmailAddress), new MailAddress("mscerror@marketsharpm.com"), context.Request.Url.Host + " MSC ERROR!", emailMsgBody.ToString());
        //        }
        //        catch (SmtpException)
        //        {
        //            // proceed without sending email.
        //        }
        //    }
        //#endregion

        //    return exceptionId;
        //}

        //private String GetDomain(String requestUrl)
        //{
        //    //localhost (dev machine)
        //    if (requestUrl.ToLower().Contains("localhost"))
        //        return "localhost";

        //    //stage-svr-appdb
        //    if (requestUrl.Contains("holmenvysa.com") || requestUrl.ToLower().Contains("holmenvysa"))
        //        return "holmenvysa";

        //    String[] tmpArray = requestUrl.Replace(@"http://", "").Replace(@"https://", "").Split('.');

        //    if (tmpArray.Length > 0)
        //        return tmpArray[0];
        //    else
        //        return String.Empty;
        //}
    }
}