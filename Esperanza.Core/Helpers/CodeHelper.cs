namespace Esperanza.Core.Helpers
{
    public static class CodeHelper
    {
        private static Random random = new Random();
        private static readonly int length = 12;

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomString(int length, bool onlyNumber = false)
        {
            string chars = onlyNumber ? "0123456789" : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
