using BLL.Interfaces;
using BLL.Models;
using ReseauSocial.Wpf.Mappers;
using ReseauSocial.Wpf.Models;
using ReseauSocial.Wpf.Tools.Sessions;
using ReseauSocial.Wpf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mvvm.Commands;
using Tools.Patterns.Mvvm.ViewModels;

namespace ReseauSocial.Wpf.ViewModels.User
{
    public class UserDetailVM : ViewModelBase<UserWpf>
    {
        private readonly IUserBll _userService;
        private readonly ISessionHelpers _sessionHelpers;
   

        public UserDetailVM(IUserBll userService, ISessionHelpers sessionHelpers, UserWpf user) : base(user)
        {
            _userService = userService;
            _sessionHelpers = sessionHelpers;

            LastName = user.LastName;
            FirstName = user.FirstName;
            Email = user.Email;
            IsAdmin = user.IsAdmin;
            Status = user.Status;
        }

        public int Id
        {
            get { return Entity.Id; }
        }


        private string _firstName;   
        public string FirstName
        {
            get { return _firstName; }
            set { Set(ref _firstName, value); }

        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { Set(ref _lastName, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { Set(ref _isAdmin, value); }
        }

        private StatusBll _statusBll;
        public StatusBll Status
        {
            get { return _statusBll; }
            set { Set(ref _statusBll, value); }
        }

        public void refresh()
        {
            if (_sessionHelpers.CurentUser is null)
                return;
            string token = _sessionHelpers.CurentUser.Token;
            UserWpf user = _userService.GetUser(Id,token).UserBllToUserWpf();
            user.Status = _userService.GetStatus(Id, token);
            LastName = Entity.LastName = user.LastName;
            FirstName = Entity.FirstName = user.FirstName;
            IsAdmin = Entity.IsAdmin = user.IsAdmin;
            Email = Entity.Email = user.Email;
            Status = Entity.Status = user.Status;

        }

        private ICommand _blockCommand;
        public ICommand BlockCommand
        {
            get { return _blockCommand ??= new DelegateCommand(Block, CanBlock); }
        }

        public void Block()
        {
            _userService.BlockedStatusAdmin(Id,_sessionHelpers.CurentUser.Id,_sessionHelpers.CurentUser.Token);
            refresh();
        }

        private bool CanBlock()
        {
            return Status.Id == (int)StatusType.Actived;   
        }

        private ICommand _unblockCommand;
        public ICommand UnblockCommand
        {
            get { return _unblockCommand ??= new DelegateCommand(UnBlock, CanUnBlock); } 
        }

        public void UnBlock()
        {
            _userService.UnBlockedStatusAdmin(Id, _sessionHelpers.CurentUser.Id, _sessionHelpers.CurentUser.Token);
            refresh();
        }

        private bool CanUnBlock()
        {
            return Status.Id == (int)StatusType.Blocked;
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ??= new DelegateCommand(Delete, CanDelete); } 
        }

        public void Delete()
        {
            _userService.DeleteStatusAdmin(Id, _sessionHelpers.CurentUser.Id, _sessionHelpers.CurentUser.Token);
            refresh();

        }

        private bool CanDelete()
        {
            return Status.Id == (int)StatusType.AskDeleted;
        }


        private ICommand _reactivateCommand;
        public ICommand ReactivateCommand
        {
            get { return _reactivateCommand ??= new DelegateCommand(Reactivate, CanReactivate); } 
        }

        public void Reactivate()
        {
            _userService.ReactivateStatusAdmin(Id, _sessionHelpers.CurentUser.Id, _sessionHelpers.CurentUser.Token);
            refresh();

        }

        private bool CanReactivate()
        {
            return Status.Id == (int)StatusType.AskReactived;
        }


    }
}