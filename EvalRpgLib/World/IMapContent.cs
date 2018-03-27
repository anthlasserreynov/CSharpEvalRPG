using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.World
{

    // Init map content
    public interface IMapContent
    {

        // Map location
        MapElement Location { get; set; }

    }
}
