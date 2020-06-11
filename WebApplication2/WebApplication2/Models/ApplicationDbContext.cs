﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
    }
}