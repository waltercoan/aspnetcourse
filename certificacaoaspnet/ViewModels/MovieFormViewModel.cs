using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genres> Genres { get; set; }
    }
}