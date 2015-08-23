using System.Collections.Generic;

namespace AppStudio.Data
{
    public static class OAuthTokensRepository
    {
        private static Dictionary<long, OAuthTokens> Tokens { get; set; }

        static OAuthTokensRepository()
        {
            Tokens = new Dictionary<long, OAuthTokens>();


            Tokens.Add(3274, new OAuthTokens
                            {
                                { "ClientId", "896e960cb31a408c9ef455b182a9d96f" }
                            });

            Tokens.Add(3277, new OAuthTokens
                            {
                                { "ConsumerKey", "ZYrqiSTk5EvLoEGWhOPmJnnge" },
                                { "ConsumerSecret", "hYykmFmSjaGI6k7oyFkZ7ZEHJ5YDU6HpcQOVX4o0smEYcIM477" },
                                { "AccessToken", "2998055836-RhHZLFVBgjIj6nbEQYU5fX0LMh2oHZINNEI3rNj" },
                                { "AccessTokenSecret", "t2QX19IJCGqG5Zw8b5wtKkkSOjusP6YcUvBNO2jbWG4ma" }
                            });

        }

        public static OAuthTokens GetTokens(long key)
        {
            if (Tokens.ContainsKey(key))
            {
                return Tokens[key];
            }
            return null;
        }

    }
}
