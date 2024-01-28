namespace CustomChatFormat
{
    public class Formats
    {
        public static Placeholders Placeholders;

        public static void UpdatePlaceholders()
        {
            // do stuff
        }
        
        public static string Reformat(string formatable)
        {
            string retval = formatable;
            retval = retval.Replace("{c:", "<color=");
            return retval;
        }
    }

    public class Placeholders
    {
        public string Player = "undefined";
        public string PlayerDisplay = "undefined";
        public string Server = "undefined";
        public string ServerOnline = "undefined";
    }
}