using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using OrleansExample.Server.Interfaces;

namespace OrleansExample.Server.Grains {
    public class Dummy : Grain, IDummy {
    }
}
