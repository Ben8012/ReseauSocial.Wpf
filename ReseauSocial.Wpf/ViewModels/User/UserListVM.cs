using BLL.Interfaces;
using ReseauSocial.Wpf.Mappers;
using ReseauSocial.Wpf.Models;
using ReseauSocial.Wpf.Models.Enums;
using ReseauSocial.Wpf.Tools.Sessions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mvvm.Commands;
using Tools.Patterns.Mvvm.ViewModels;

namespace ReseauSocial.Wpf.ViewModels.User
{
    public class UserListVM : ViewModelCollectionBase<UserDetailVM>
    {
        private readonly IUserBll _userBllService;
        private readonly ISessionHelpers _sessionHelpers;

        public UserListVM(IUserBll userBllService, ISessionHelpers sessionHelpers)
        {
            _userBllService = userBllService;
            _sessionHelpers = sessionHelpers;
        }

        protected override ObservableCollection<UserDetailVM> LoadItems()
        {
            if (_sessionHelpers.CurentUser is null)
                return new ObservableCollection<UserDetailVM>();
            string token = _sessionHelpers.CurentUser.Token;
            IEnumerable<UserWpf> userList = _userBllService.GetAllUsers(token)
                .Where(u => !u.IsAdmin)
                .Select(u =>
            {
                u.Status = _userBllService.GetStatus(u.Id, token);
                return u.UserBllToUserWpf();

            });


            if (SelectedStatus != StatusType.All)
            {
                userList = userList.Where(u => u.Status.Id == (int)SelectedStatus);
            }

            return new ObservableCollection<UserDetailVM>(userList.Select(u => new UserDetailVM(_userBllService,_sessionHelpers, u)));
        }

        #region Filtre status user

        private StatusType _selectedStatus = StatusType.All;

        public StatusType SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                Set(ref _selectedStatus, value);
                Refresh();
            }
        }

        #endregion

        private UserDetailVM _selectedItem;

        public UserDetailVM SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem , value); }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get { return _refreshCommand ??= new DelegateCommand(Refresh); }
        }

        public void Refresh()
        {
            ObservableCollection<UserDetailVM> listUser = LoadItems();
            Items.Clear();
            foreach(UserDetailVM user in listUser)
            {
                Items.Add(user);
            }
        }


    }
}
