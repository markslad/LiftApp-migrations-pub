﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftApp.Dal.Models
{
    public class NonEntrepreneurCustomer : Customer
    {
        public string FirstName { get; set; } = default!;

        public string Surname { get; set; } = default!;
    }
}
