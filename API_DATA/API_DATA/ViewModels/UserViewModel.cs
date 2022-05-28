using API_DATA.Models;
using API_DATA.Services;
using API_DATA.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace API_DATA.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private string _SearchText;

        public string SearchText
        {
            get => _SearchText;
            set => SetProperty(ref _SearchText, value);
        }

        private bool _isrefresh = false;

        public bool IsRefresh
        {
            get => _isrefresh;
            set => SetProperty(ref _isrefresh, value);
        }

        private ObservableCollection<UserData> _userData;
        public ObservableCollection<UserData> userDatas { get => _userData; set => SetProperty(ref _userData, value); }
        IUserService userService;
        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand DetailCommand { get; }
        public UserViewModel()
        {
            userService = DependencyService.Get<IUserService>();
            GetData();
            SearchCommand = new Command<object>(SearchData);
            RefreshCommand = new Command<object>(RefreshData);
            DetailCommand = new Command<object>(SelectedItem);
        }

        private void SelectedItem(object obj)
        {
            var data = obj as UserData;
            userService.PilihanUser(data);
            Application.Current.MainPage.Navigation.PushAsync(new DetailUserPage());
        }

        private async void RefreshData(object obj)
        {
            await userService.RefreshDataAsync();
            userDatas = userService.userDatas;
            IsRefresh = false;
        }

        async void GetData()
        {
            await userService.RefreshDataAsync();
            userDatas = userService.userDatas;
        }
        void SearchData(object args)
        {
            var Todoitem = args as UserData;
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                userDatas = userService.userDatas;

            }
            else
            {
                userDatas = new ObservableCollection<UserData>(_userData.Where(i => i.Username.ToLower().Contains(SearchText.ToLower())));
            }
            //userDatas = userService.userDatas;
        }
    }
}
