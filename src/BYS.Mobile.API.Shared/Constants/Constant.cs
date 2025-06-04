namespace BYS.Mobile.API.Shared.Constants
{
    public static class Common
    {
        public const int VietnamTimeZoneOffset = 7;
        public const int PageSizeMax = 200;
        public const int PageSizeMin = 10;
    }

    public class Constant
    {
        public const int VietNamTimeZoneOffset = 7;
        public const int MinPageIndexValue = 1;
        public const int MinPageSizeValue = 10;
        public const int MaxPageSizeValue = 1000;
        public const int MaxPageSizeEls = 10000;
        public const string DefaultLang = "vi";
        public const string DEFAULT_CURRENCY_CODE = "VND";
        public const string USD_CURRENCY_CODE = "USD";
        public const string PLATFORM_B2B = "B2B";
        public const string PLATFORM_Expo = "TradeXpo";

        /// <summary>
        /// Hệ số rating đang * 2 trong DB
        /// </summary>
        public const int RATING_COEFFICIENT = 2;

        public const int TOP_SEARCH_PRODUCT_BY_BUSINESS = 4;
        public const int TOP_AI_SIMILAR_PRODUCT = 3;
        public const string TRANSLATION_ENDPOINT = "/v1beta/models/gemini-1.5-flash:generateContent";
    }

    public static class RedisKey
    {
        public const string ChatUserFormat = "ChatUser_{0}";
    }

    public static class KafkaKey
    {
#if DEBUG
        public const string ArobidMessageKey = "arobid-message-for-dev";
#else
        public const string ArobidMessageKey = "arobid-message";
#endif
    }

    public static class KafkaTopic
    {
#if DEBUG
        public const string ArobidChatTopic = "arobid-chat-for-dev";
#else
        public const string ArobidChatTopic = "arobid-chat";
#endif
    }

    public class MessageConstants
    {
        public class Type
        {
            public const string Normal = "normal";
            public const string System = "system";
        }
        public class ActionType
        {
            public const string RFQ = "rfq";
            public const string Chat = "chat";
            public const string Notify = "notify";
        }
    }

    public class Status
    {
        public const string ALIVE = "Alive";
    }
}
