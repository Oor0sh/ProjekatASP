using aspPopravni.Application.Logging;
using System.Text;

namespace aspPopravni.API.ErrorLogging
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void Log(AppError error)
        {
            var errorDate = DateTime.UtcNow;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Error code: " + error.ErrorId.ToString());
            builder.AppendLine("User: " + error.Email != null ? error.Email : "/");
            builder.AppendLine("Error time:" + errorDate.ToLongDateString());
            builder.AppendLine("Ex message:" + error.Exception.Message);
            builder.AppendLine("Ex stack trace:");
            builder.AppendLine(error.Exception.StackTrace);

            Console.WriteLine(builder.ToString());
        }
    }
}
