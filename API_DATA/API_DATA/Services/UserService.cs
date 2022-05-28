using API_DATA.Models;
using API_DATA.Services;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserService))]
namespace API_DATA.Services
{
    public class UserService : BaseViewModel, IUserService
    {
        HttpClient httpClient = new HttpClient();
        private const string url = "https://62904d3e27f4ba1c65b6d578.mockapi.io/api/books";

        private ObservableCollection<UserData> _userData;
        public ObservableCollection<UserData> userDatas { get=>_userData; set=>SetProperty(ref _userData,value); }
        public UserService()
        {
            RefreshDataAsync();
        }
        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task RefreshDataAsync()
        {
            string content = await httpClient.GetStringAsync(url);
            List<UserData> users = JsonConvert.DeserializeObject<List<UserData>>(content);
            userDatas = new ObservableCollection<UserData>(users);
        }

        public Task SaveTodoItemAsync(UserData item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoItemAsync(UserData item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }
    }
}
