using Ispit_2017_02_15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModels
{
    public class StudentiUrediViewModel
    {
        public Detalj OdrzaniCasDetalj { get; set; }

        public class Detalj
        {
            public int OdrzaniCasId { get; set; }
            public int OdrzaniCasDetaljId { get; set; }
            public string Student { get; set; }
            public int Bodovi { get; set; }
        }
    }
}
