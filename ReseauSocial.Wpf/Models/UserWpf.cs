﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Models
{
    public class UserWpf
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public StatusBll Status { get; set; }

        public string Token { get; set; }
    }
}
