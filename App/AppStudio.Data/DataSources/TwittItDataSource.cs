using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class TwittItDataSource : DataSourceBase<TwitterSchema>
    {
        private const long OAuthKey = 3277;
        private const string TwitterQuery = "thedjangos";

        protected override string CacheKey
        {
            get { return "TwittItDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<TwitterSchema>> LoadDataAsync()
        {
            try
            {
                var provider = new TwitterProvider();

                return await provider.GetUserTimeLineAsync(TwitterQuery, OAuthTokensRepository.GetTokens(OAuthKey));
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("TwittItDataSourceDataSource.LoadData", ex.ToString());
                return new TwitterSchema[0];
            }
        }
    }
}
