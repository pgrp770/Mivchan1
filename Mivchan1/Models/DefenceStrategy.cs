using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mivchan1.Models
{
    internal class DefenceStrategy
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public static bool operator <(DefenceStrategy d1, DefenceStrategy d2)
        {
            return d1.MinSeverity < d2.MinSeverity && d1.MaxSeverity < d2.MaxSeverity;
        }
        public static bool operator >(DefenceStrategy d1, DefenceStrategy d2)
        {
            return d1.MaxSeverity > d2.MaxSeverity && d1.MinSeverity > d2.MinSeverity;
        }
        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity}] Defences: {string.Join(", ", Defenses)}";
        }
    }
}
