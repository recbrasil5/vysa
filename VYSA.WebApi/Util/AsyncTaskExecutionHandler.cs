﻿using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace VYSA.WebApi.Util
{
    public class AsyncTaskExecutionHandler
    {
        public ExceptionDispatchInfo CapturedException { get; set; }

        public async Task ExecuteAndHandleErrorAsync(Func<Task> actionAsync,
            Func<Exception, Task<bool>> errorHandlerAsync)
        {

            //http://stackoverflow.com/questions/16626161/a-good-solution-for-await-in-try-catch-finally/16626313#16626313
            //ExceptionDispatchInfo capturedException = null;
            try
            {
                await actionAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                CapturedException = ExceptionDispatchInfo.Capture(ex);
            }

            if (CapturedException != null)
            {
                var needsThrow = await errorHandlerAsync(CapturedException.SourceException).ConfigureAwait(false);
                if (needsThrow)
                {
                    CapturedException.Throw();
                }
            }
        }

        public async Task<bool> LogExceptionAsyncTask(Exception ex)
        {
            //Aysynchronously Log exception to the database
            return true;  //not sure why we'd ever want to return false or what effect that'd have...
        }
    }
}