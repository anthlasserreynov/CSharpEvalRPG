using EvalRpgLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvalRpgLib.World
{
    public class MapElement
    {
        // Init map
        public Map Map { get; set; }

        // Init neighbors dictionary
        public Dictionary<DirectionEnum, MapElement> Neighbors { get; set; }

        // X Position of the element
        public int X { get; set; }

        // Y Position of the element
        public int Y { get; set; }
         
        // List content on this map position
        public List<IMapContent> ContentList { get; set; }

        
        // Map elements constructor
        public MapElement(Map map, int x, int y)
        {
            this.Map = map;
            this.X = x;
            this.Y = y;
            ContentList = new List<IMapContent>();
            Neighbors = new Dictionary<DirectionEnum, MapElement>();
        }

        // Search map neighbors -> Save in dictionary
        public void SearchNeighbors()
        {
            foreach(DirectionEnum Direction in Enum.GetValues(typeof(DirectionEnum))){
                Neighbors.Add(Direction, GetNeighbour(Direction));
            }
        }

        
        // Search neighbors with a direction parameter
        public MapElement GetNeighbour(DirectionEnum direction)
        {
            if(direction == DirectionEnum.Est){
                if (Y+1 < this.Map.Matrix.GetLength(1))
                {
                    return (EvalRpgLib.World.MapElement)Map.Matrix[X, Y+1];
                }
            } else if (direction == DirectionEnum.West) {
                if (Y-1 >= 0)
                {
                    return (EvalRpgLib.World.MapElement)Map.Matrix[X, Y-1];
                }
            } else if (direction == DirectionEnum.South) {
                if (X+1 < Map.Matrix.GetLength(0))
                {
                    return (EvalRpgLib.World.MapElement)Map.Matrix[X+1, Y];
                }
            } else if (direction == DirectionEnum.North) {
                if (X-1 >= 0)
                {
                    return (EvalRpgLib.World.MapElement)Map.Matrix[X-1, Y];
                }
            }
            return null;
        }

        
        // Add Content to position
        public void AddContent(IMapContent content)
        {
            if (content != null)
            {
                if(content.Location != null){
                    if(content.Location.X != this.X || content.Location.Y != this.Y) {
                        content.Location.RemoveContent(content);
                    }
                }
                content.Location = this;
                ContentList.Add(content);
            }
        }

        
        // Remove content to position
        public void RemoveContent(IMapContent content)
        {
            ContentList.Remove(content);
        }

        public override string ToString()
        {
            return string.Format("[x={0},y={1}]", X, Y);
        }
    }
}
