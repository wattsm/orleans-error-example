using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using OrleansErrorExample.Interfaces;

namespace OrleansErrorExample.Grains {
    public class Dummy : Grain, IDummy {
    }
}
