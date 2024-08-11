using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorAPI.Models
{
    public class CalculationResult
    {
        [DefaultValue(null)]
        public double? Result { get; set; }
        [DefaultValue(null)]
        public string? Error { get; set; }

    }
}
