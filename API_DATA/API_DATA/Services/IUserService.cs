using API_DATA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace API_DATA.Services
{
    public interface IUserService
    {
        Task RefreshDataAsync();
        Task SaveTodoItemAsync(UserData item, bool isNewItem = false);
        Task UpdateTodoItemAsync(UserData item, bool isNewItem = false);
        Task DeleteTodoItemAsync(string id);
        ObservableCollection<UserData> userDatas { get; set; }
    }
}
