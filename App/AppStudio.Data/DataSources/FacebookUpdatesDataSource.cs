using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class FacebookUpdatesDataSource : DataSourceBase<FacebookSchema>
    {
        private const string _userID = "99636325744";

        protected override string CacheKey
        {
            get { return "FacebookUpdatesDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return false; }
        }

        public async override Task<IEnumerable<FacebookSchema>> LoadDataAsync()
        {
            try
            {
                var facebookDataProvider = new FacebookDataProvider(_userID);
                return await facebookDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("FacebookUpdatesDataSourceDataSource.LoadData", ex.ToString());
                return new FacebookSchema[0];
            }
        }
    }
}
