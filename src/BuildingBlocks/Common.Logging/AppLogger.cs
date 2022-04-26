using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public static class AppLogger
    {
        public static void LogAppError<T>(this ILogger<T> logger, LogCategory category, string message, params object?[] args)
        {
            if (string.IsNullOrEmpty(message) || args == null) return;

            var arguments = new object?[args.Length + 1];
            arguments[0] = category.ToString();
            Array.Copy(args, 0, arguments, 1, args.Length);

            logger.LogError(string.Concat("{LogCategory}", message), arguments);
        }
    }
}
