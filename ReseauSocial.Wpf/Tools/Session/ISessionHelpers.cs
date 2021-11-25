using ReseauSocial.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Tools.Sessions

{
    public interface ISessionHelpers
    {
        UserSession CurentUser { get; set; }
        void clearUserSession();


    }
}
