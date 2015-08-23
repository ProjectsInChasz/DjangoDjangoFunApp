using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class YouTubeChannelDetail : Page
    {
        private DataTransferManager _dataTransferManager;

        private NavigationHelper _navigationHelper;

        private DisplayOrientations _currentOrientations;

        public YouTubeChannelDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            ytViewer.NavigationHelper = _navigationHelper;

            YouTubeChannelModel = new YouTubeChannelViewModel();

            DataContext = this;

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public YouTubeChannelViewModel YouTubeChannelModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (YouTubeChannelModel != null)
            {
                await YouTubeChannelModel.LoadItemsAsync();
                YouTubeChannelModel.SelectItem(e.Parameter);

                YouTubeChannelModel.ViewType = ViewTypes.Detail;
            }

            ytViewer.OnNavigatedTo();

            // Allow this page to rotate
            _currentOrientations = DisplayInformation.AutoRotationPreferences;
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait
                                                        | DisplayOrientations.Landscape
                                                        | DisplayOrientations.LandscapeFlipped
                                                        | DisplayOrientations.PortraitFlipped;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);

            _navigationHelper.OnNavigatedFrom(e);
            
            ytViewer.EmbedUrl = null;

            ytViewer.OnNavigatedFrom();

            // Restore previous rotation preferences
            DisplayInformation.AutoRotationPreferences = _currentOrientations;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (YouTubeChannelModel != null)
            {
                YouTubeChannelModel.GetShareContent(args.Request);
            }
        }
    }
}
