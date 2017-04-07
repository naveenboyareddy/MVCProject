using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly1.Models;

namespace Vidly1.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> genres { set; get; }
        public Movie movies { get; set; }
        public string Title
        {
            get
            {
                     if(movies != null && movies.Id !=0)

                return "Edit Movie";   

                    return "New Movie";
            }
        }
    }
}