using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace measure
{
    class Command
    {
        public virtual List<String> get_command_string() { return new List<String>(); }
    }
}
