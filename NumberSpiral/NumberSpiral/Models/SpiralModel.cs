using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberSpiral.Models
{
    public class SpiralModel
    {
        public int RowColCount { get; set; }
        public int[,] SpiralMatrix { get; set; }
    }
}