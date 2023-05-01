﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Model
{
   public  class Client
    {
        public int ClientId { get; set; }
     
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BornDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
