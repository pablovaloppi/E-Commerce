﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Parameters
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 50;

        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;

        public int PageSize { 
            get {
                return _pageSize;
            }
            set {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
