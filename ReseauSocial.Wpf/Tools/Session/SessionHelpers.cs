using ReseauSocial.Wpf.Models;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Tools.Sessions
{
    public class SessionHelpers : ISessionHelpers
    {
        private static Dictionary<string, object> _session = new Dictionary<string, object>();


        public UserSession CurentUser
        {
            get
            {
                if (!_session.ContainsKey(nameof(CurentUser)))
                    return null;

                if (_session.GetValueOrDefault(nameof(CurentUser)) is null)
                    return null;

                return (UserSession)_session.GetValueOrDefault(nameof(CurentUser));
            }
            set
            {
                if (!_session.ContainsKey(nameof(CurentUser)))
                    _session.Add(nameof(CurentUser), value);
                else _session[nameof(CurentUser)] = value;
            }
        }


        public void clearUserSession()
        {
            _session.Remove(nameof(CurentUser));
        }

    }
}
