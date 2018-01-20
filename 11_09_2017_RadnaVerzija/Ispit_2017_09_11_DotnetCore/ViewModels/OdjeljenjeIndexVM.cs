using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeIndexVM
    {
        public class Row
        {
            public int OdjeljenjeID;
            public string SkolskaGodina;
            public int Razred;
            public string Oznaka;
            public string Razrednik;
            public bool Prebacen;
            public string NajboljiUcenik;
            public float ProsjekOcjena;
        }

        public List<Row> Rows;
    }
}
