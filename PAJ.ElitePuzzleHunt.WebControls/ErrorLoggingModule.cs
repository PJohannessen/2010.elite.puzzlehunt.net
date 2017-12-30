using System;
using System.Web;
using PAJ.ElitePuzzleHunt.Data;

namespace PAJ.ElitePuzzleHunt.WebControls
{
    public class ErrorLoggingModule : IHttpModule
    {
        private const string ErrorLogTemplate = "An error has occured! Message: {0}. Stack trace: {1}";

        public void Init(HttpApplication context)
        {
            context.Error += ErrorHandler;
        }

        private static void ErrorHandler(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.AllErrors != null)
                {
                    using (var dataContext = new DatabaseDataContext(DatabaseConfig.ConnectionString))
                    {
                        foreach (Exception unhandledException in HttpContext.Current.AllErrors)
                        {
                            Logging log = new Logging
                            {
                                Time = DateTime.UtcNow,
                                Message = string.Format(ErrorLogTemplate, unhandledException.Message, unhandledException.StackTrace)
                            };
                            dataContext.Loggings.InsertOnSubmit(log);
                        }
                        dataContext.SubmitChanges();
                    }
                }
            }
            catch
            {
            }
        }

        public void Dispose()
        {
        }
    }
}
