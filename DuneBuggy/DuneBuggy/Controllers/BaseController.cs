using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuneBuggy.Businesslayer.Models;
using DuneBuggy.Businesslayer.Helpers;
using DuneBuggy.Datalayer.UnitOfWork;

namespace DuneBuggy.Controllers
{   
    public partial class BaseController : Controller
    {
        private UnitOfWork _context;

        public UnitOfWork Context
        {
            get
            {
                return _context ?? new UnitOfWork(); 
            }
            private set
            {
                _context = value;
            }
        }

    }
}