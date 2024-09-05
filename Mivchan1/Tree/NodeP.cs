﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mivchan1.Models;

namespace Mivchan1.Tree
{
    internal class NodeP
    {
        public NodeP(DefenceStrategy defence)
        {
            Defence = defence;
        }

        public DefenceStrategy Defence { get; set; }
        public NodeP? Left { get; set; }
        public NodeP? Right { get; set; }
        public int? Height { get; set; }

    }
}

