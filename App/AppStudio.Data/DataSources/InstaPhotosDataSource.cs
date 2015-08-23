using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class InstaPhotosDataSource : DataSourceBase<InstagramSchema>
    {
        private const long OAuthKey = 3274;
        private const string QueryType = "tag";
        private const string Query = "DjangoDjango";

        protected override string CacheKey
        {
            get { return "InstaPhotosDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<InstagramSchema>> LoadDataAsync()
        {
            try
            {
                var instagramProvider = new InstagramDataProvider(QueryType,Query,OAuthTokensRepository.GetTokens(OAuthKey));
                return await instagramProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("InstaPhotosDataSourceDataSource.LoadData", ex.ToString());
                return new InstagramSchema[0];
            }
        }
    }
}
