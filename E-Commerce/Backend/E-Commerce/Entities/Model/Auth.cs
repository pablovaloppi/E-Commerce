﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Auth
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public string Token { get; set; }

    }
}
