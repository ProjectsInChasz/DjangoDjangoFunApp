using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStudio.Data
{
    public class AboutAppDataSource : DataSourceBase<HtmlSchema>
    {
        private const string HtmlSource = "/Assets/Data/AboutAppDataSource.htm";

        protected override string CacheKey
        {
            get { return "AboutAppDataSource"; }
        }

        public override bool HasStaticData
        {
            get { return true; }
        }

        public async override Task<IEnumerable<HtmlSchema>> LoadDataAsync()
        {
            try
            {
                var serviceDataProvider = new StaticHtmlDataProvider(HtmlSource);
                return await serviceDataProvider.Load();
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("AboutAppDataSource.LoadData", ex.ToString());
                return new HtmlSchema[0];
            }
        }
    }
}
