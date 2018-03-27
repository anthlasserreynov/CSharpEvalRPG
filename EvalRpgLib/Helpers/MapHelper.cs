using EvalRpgLib.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.Helpers
{
    public static class MapHelper
    {
        
        // Return shit X and Y with a direction
        public static int[] GetDirectionOffset(DirectionEnum direction)
        {
            if(direction == DirectionEnum.North) {
                return new int[] { -1 , 0 };
            } else if (direction == DirectionEnum.Est)
            {
                return new int[] { 0, 1 };
            } else if (direction == DirectionEnum.West)
            {
                return new int[] { 0, -1 };
            } else if (direction == DirectionEnum.South)
            {
                return new int[] { 1, 0 };
            }
            return new int[] { 0, 0 };
        }



    }
}
