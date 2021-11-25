using BLL.Interfaces;
using BLL.Models;
using ReseauSocial.Wpf.Models;
using ReseauSocial.Wpf.Tools.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Patterns.Mediator;
using Tools.Patterns.Mvvm.Commands;
using Tools.Patterns.Mvvm.ViewModels;

namespace ReseauSocial.Wpf.ViewModels
{
    public class LoginVM : ViewModelBase
    {
        private readonly IUserBll _userBllService;
        private readonly ISessionHelpers _sessionHelpers;
        public LoginVM(IUserBll userBllService, ISessionHelpers sessionHelpers)
        {
            _userBllService = userBllService;
            _sessionHelpers = sessionHelpers;
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get { return _loginCommand ??= new DelegateCommand(Login, CanLogin); } 
        }


        private bool CanLogin()
        {
                return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrEmpty(Passwd);
        }
        public void Login()
        {
            UserBll user = _userBllService.Login(Email,Passwd);
            
            if (user is not null && user.IsAdmin)
            {
                _sessionHelpers.CurentUser = new UserSession
                {
                    Id = user.Id,
                    Email = user.Email,
                    Token = user.Token
                };
                Messenger<WindowTypes>.Default.Send(WindowTypes.Main);

            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email , value); }
        }

        private string _passwd;

        public string Passwd
        {
            get { return _passwd; }
            set {  Set(ref _passwd, value); }
        }




    }
}
