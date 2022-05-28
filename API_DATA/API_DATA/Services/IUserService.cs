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
        Task DeleteTodoItemAsync(UserData item);
        ObservableCollection<UserData> userDatas { get; set; }
        UserData userTerpilih { get; set; }
        void PilihanUser(UserData user);
    }
}
