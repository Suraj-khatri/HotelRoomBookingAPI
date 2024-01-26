using BookingSystem.Debugging;

namespace BookingSystem
{
    public class BookingSystemConsts
    {
        public const string LocalizationSourceName = "BookingSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "af7657e811864db8b5ffcb37550827bc";
    }
}
