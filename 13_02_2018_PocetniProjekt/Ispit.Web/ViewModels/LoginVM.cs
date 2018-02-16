using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUniverzitet.Web.ViewModels
{
    public class LoginVM
    {
        public string username { get; set; }
        public List<SelectListItem> usersList { get; set; }

    }
}
