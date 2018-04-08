using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4ED1.Clases
{
    public class Sticker
    {
        int number;
        string NCountry;

        public int Number { get => number; set => number = value; }
        public string NCountry_ { get => NCountry; set => NCountry = value; }

        public Sticker(int n, string name)
        {
            Number = n;
            NCountry_ = name;
        }
    }
}