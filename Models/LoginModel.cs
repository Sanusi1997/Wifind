﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WiFind.Models
{
    public class LoginModel
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}

