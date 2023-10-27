﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course {
    class Product {
        public string Name;
        public double Price;
        public int Unity;

        public double TotalPriceInStock() {
            return Price * Unity;
        }

        public override string ToString() {
            return $"Nome: {Name}\nPreço: R${Price}\nUnidades: {Unity}\nPreço total: R${TotalPriceInStock():F2}";
        }
    }
}