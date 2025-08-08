using System;
namespace WSReciboAcomodoITK.NetCoreAPI.Infrastructure
{
    public static class Logs
    {
        /// <summary>
        /// Simulates logging of operations. Replace with real logging as needed.
        /// </summary>
        public static void InsertarLogOperaciones(string mensaje, int severidad, params object[] parametros)
        {
            // Get caller method name
            var trace = new System.Diagnostics.StackTrace();
            var frame = trace.GetFrame(1); // 1 to get the immediate caller
            var callerMethodName = frame?.GetMethod()?.Name ?? "UnknownMethod";

            var paramStr = parametros != null && parametros.Length > 0 ? $" | Params: {string.Join(", ", parametros)}" : string.Empty;
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [LOG][{severidad}] [Caller:{callerMethodName}] {mensaje}{paramStr}";
            Console.WriteLine(logEntry);

            // Delegate file logging to FileLogOperaciones
            FileLogOperaciones(logEntry, severidad);
        }
            /// <summary>
            /// Writes log message to a file with severity and timestamp (legacy FileLogOperaciones).
            /// </summary>
            public static void FileLogOperaciones(string mensaje, int severidad)
            {
                try
                {
                    var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WSReciboAcomodoITK.log");
                    var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [SEVERITY:{severidad}] {mensaje}";
                    File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LOGGING ERROR] {ex.Message}");
                }
            }
    }
}
