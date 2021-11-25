using BLL.Interfaces;
using ReseauSocial.Wpf.Tools.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.ViewModels
{
    public class MainVM
    {
        private readonly IUserBll _userBllService;
        private readonly ISessionHelpers _sessionHelpers;
        public MainVM(IUserBll userBllService, ISessionHelpers sessionHelpers)
        {
            _userBllService = userBllService;
            _sessionHelpers = sessionHelpers;
        }


    }
}
