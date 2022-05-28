using API_DATA.Models;
using API_DATA.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace API_DATA.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        UserData _userData;
        public UserData userData { get=>_userData; set=>SetProperty(ref _userData,value); }

        IUserService userService;
        public ICommand DeleteCommand { get; }
        public UserDetailViewModel()
        {
            userService = DependencyService.Get<IUserService>();
            userData = userService.userTerpilih;
            DeleteCommand = new Command<object>(DeleteData);
        }

        private void DeleteData(object obj)
        {
            userData = userService.userTerpilih;
            userService.DeleteTodoItemAsync(userData);
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
