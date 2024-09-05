using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mivchan1.Models;

namespace Mivchan1.Utils
{
    static internal class ThreatUtils
    {
        static public int GetTargetValue(string target) => target switch
        {
            "Web Server" => 10,
            "Database" => 15,
            "User Credentials" => 20,
            _ => 5
        };


        static public int CalculateSeverity(Threat thret) =>
            (thret.Volume * thret.Sophistication) + GetTargetValue(thret.Target);
        static public bool IsThreatInTheSeverityRange(Threat threat, DefenceStrategy defence)
        {
            int threatSevirity = CalculateSeverity(threat);
            return threatSevirity >= defence.MinSeverity && threatSevirity <= defence.MaxSeverity;
        }



    }
}
