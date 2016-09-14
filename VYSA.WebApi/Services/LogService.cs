﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using VYSA.WebApi.Properties;
using VYSA.WebApi.Providers;

namespace VYSA.WebApi.Services
{
    public class LogService
    {
        public const Int16 MaxExceptionCount = 1000;
        //private readonly MscSystemControlRepository<ExceptionLog> _exceptionRepository;

        public LogService()
        {
            //_exceptionRepository = new MscSystemControlRepository<ExceptionLog>(new MSCSystemControlEntities());
        }

        public int LogError(Exception ex, string addtlInfo, Boolean saveToDatabase, Boolean emailAdminNotification, string email)
        {
            var sb = new StringBuilder();

            var context = HttpContext.Current;
            var timestamp = DateTime.Now;
            var timestampUtc = DateTime.Now.ToUniversalTime();
            String source = !String.IsNullOrEmpty(ex.Source) ? ex.Source : "";
            //var target = !String.IsNullOrEmpty(ex.TargetSite.Name) ? ex.TargetSite.Name : "";
            var exceptionType = ex.GetType().ToString();
            var message = ex.Message;
            var stackTrace = ex.StackTrace;
            var requestIp = context.Request.UserHostAddress;
            var requestUrl = context.Request.Url.AbsoluteUri;
            //int exceptionId = -1;

            var sqlException = ex as SqlException;
            if (sqlException != null)
            {
                foreach (var error in sqlException.Errors)
                    sb.AppendLine(String.Format("SqlError: {0}", error));
            }

            #region Save to DB
            //if (saveToDatabase)
            //{
            //    //build the Entity
            //    var el = new ExceptionLog
            //    {
            //        UserName = accountUserId,
            //        Domain = GetDomain(requestUrl),
            //        Request_IP = requestIp,
            //        Request_URL = requestUrl,
            //        ExceptionType = exceptionType,
            //        TargetSite = target,
            //        Message = message,
            //        Source = source,
            //        StackTrace = stackTrace,
            //        AdditionalInfo = additionalInfo,
            //        AdditionalInfoSQLError = "",
            //        TimestampUtc = timestamp
            //    };

            //    _exceptionRepository.Add(el);
            //    _exceptionRepository.Save();
            //    _exceptionRepository.Entities.Entry(el).Reference(l => l.AccountUser).Load();

            //    exceptionId = el.Id;
            //}
            #endregion

            #region Email Exception
            if (emailAdminNotification)
            {
                try
                {
                    var emailMsgBody = new StringBuilder();
                    emailMsgBody.AppendLine("api.holmenvysa.com exception:"); emailMsgBody.AppendLine();
                    //emailMsgBody.AppendFormat("ExceptionLogId: {0}", exceptionId);
                    //emailMsgBody.AppendLine();
                    emailMsgBody.AppendFormat("Server Date/Time: {0}", timestamp.ToString("MM/dd/yyyy HH:mm:ss")).AppendLine();
                    emailMsgBody.AppendFormat("Utc Date/Time: {0}", timestampUtc.ToString("MM/dd/yyyy HH:mm:ss")).AppendLine();
                    emailMsgBody.AppendFormat("Request from IP: {0}", requestIp).AppendLine();
                    emailMsgBody.AppendFormat("Request URL: {0}", requestUrl).AppendLine();
                    emailMsgBody.AppendFormat("Client still connected: {0}", context.Response.IsClientConnected).AppendLine();
                    emailMsgBody.AppendFormat("Email: {0}", email).AppendLine();
                    emailMsgBody.AppendFormat("Exception Type: {0}", exceptionType).AppendLine();
                    emailMsgBody.AppendFormat("Message: {0}", message).AppendLine();
                    emailMsgBody.AppendFormat("Source: {0}", source).AppendLine();
                    emailMsgBody.AppendFormat("StackTrace: {0}", stackTrace).AppendLine();

                    if (!string.IsNullOrEmpty(addtlInfo))
                        emailMsgBody.AppendFormat("AdditionalInfo: {0}", addtlInfo).AppendLine();

                    if (ex is SqlException)
                    {
                        emailMsgBody.AppendFormat("{0}", sb);
                        emailMsgBody.AppendLine();
                    }

                    var subject = string.Format("{0} holmenvysa.com error!", context.Request.Url.Host);
                    EmailProvider.SendEmail("recbrasil5@gmail.com",
                                            Settings.Default.ErrorMsgFrom,
                                            subject,
                                            emailMsgBody.ToString());
                }
                catch (SmtpException)
                {
                    // proceed without sending email.
                }
            }
            #endregion

            return -1;
        }


        private String GetDomain(String requestUrl)
        {
            //localhost (dev machine)
            if (requestUrl.ToLower().Contains("localhost"))
                return "localhost";

            //stage-svr-appdb
            if (requestUrl.Contains("gt0ycivg59.database.windows.net") || requestUrl.ToLower().Contains("azure-svr"))
                return "azure-svr";

            String[] tmpArray = requestUrl.Replace(@"http://", "").Replace(@"https://", "").Split('.');

            if (tmpArray.Length > 0)
                return tmpArray[0];
            else
                return String.Empty;
        }
    }
}