namespace Esperanza.Core.Logs
{
    public static class Log
    {
        public static void Error(string path, string message)
        {
            //var date = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff");
            path = $"{path}ERROR.txt";
            //path = $"{path}{date}_ERROR.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"Error --> {message}");
                writer.Close();
            }
        }
        public static void Information(string path, string message, string prefix = "")
        {
            //var date = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff");
            path = $"{path}INFORMATION.txt";
            //path = $"{path}{date}_INFORMATION.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                prefix = string.IsNullOrEmpty(prefix) ? "Information" : prefix;
                writer.WriteLine($"{prefix} --> {message}");
                writer.Close();
            }
        }
    }
}
