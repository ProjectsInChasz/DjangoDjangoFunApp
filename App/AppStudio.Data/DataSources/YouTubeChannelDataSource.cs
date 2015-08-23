using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class YouTubeChannelDataSource : DataSourceBase<YouTubeSchema>
    {
        private const string _url = @"https://gdata.youtube.com/feeds/api/users/djangodjango/uploads?start-index=1&max-results=20&v=2";

        protected override string CacheKey
        {
            get { return "YouTubeChannelDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<YouTubeSchema>> LoadDataAsync()
        {
            try
            {
                var youTubeDataProvider = new YouTubeDataProvider(_url);
                return await youTubeDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("YouTubeChannelDataSourceDataSource.LoadData", ex.ToString());
                return new YouTubeSchema[0];
            }
        }
    }
}
