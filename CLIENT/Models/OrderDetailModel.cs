﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLIENT.Models
{
    public class OrderDetailModel
    {
        public int  ProductId { get; set; }
        public int  Quantity { get; set; }
        public double  Price { get; set; }
    }
}