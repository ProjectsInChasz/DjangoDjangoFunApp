using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private AboutBandViewModel _aboutBandModel;
       private YouTubeChannelViewModel _youTubeChannelModel;
       private FacebookUpdatesViewModel _facebookUpdatesModel;
       private InstaPhotosViewModel _instaPhotosModel;
       private TwittItViewModel _twittItModel;
       private MenuViewModel _menuModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = AboutBandModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public AboutBandViewModel AboutBandModel
        {
            get { return _aboutBandModel ?? (_aboutBandModel = new AboutBandViewModel()); }
        }
 
        public YouTubeChannelViewModel YouTubeChannelModel
        {
            get { return _youTubeChannelModel ?? (_youTubeChannelModel = new YouTubeChannelViewModel()); }
        }
 
        public FacebookUpdatesViewModel FacebookUpdatesModel
        {
            get { return _facebookUpdatesModel ?? (_facebookUpdatesModel = new FacebookUpdatesViewModel()); }
        }
 
        public InstaPhotosViewModel InstaPhotosModel
        {
            get { return _instaPhotosModel ?? (_instaPhotosModel = new InstaPhotosViewModel()); }
        }
 
        public TwittItViewModel TwittItModel
        {
            get { return _twittItModel ?? (_twittItModel = new TwittItViewModel()); }
        }
 
        public MenuViewModel MenuModel
        {
            get { return _menuModel ?? (_menuModel = new MenuViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            AboutBandModel.ViewType = viewType;
            YouTubeChannelModel.ViewType = viewType;
            FacebookUpdatesModel.ViewType = viewType;
            InstaPhotosModel.ViewType = viewType;
            TwittItModel.ViewType = viewType;
            MenuModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                AboutBandModel.LoadItemsAsync(forceRefresh),
                YouTubeChannelModel.LoadItemsAsync(forceRefresh),
                FacebookUpdatesModel.LoadItemsAsync(forceRefresh),
                InstaPhotosModel.LoadItemsAsync(forceRefresh),
                TwittItModel.LoadItemsAsync(forceRefresh),
                MenuModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
