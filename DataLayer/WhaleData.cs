using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class WhaleData
    {
        public int WhaleId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Colour { get; set; }

        public bool IsItPregnant { get; set; }
        public WhaleData(int whaleId, string name, int age, string colour, bool isItPregnant)
        {
            this.WhaleId = whaleId;
            this.Name = name;
            this.Age = age;
            this.Colour = colour;
            this.IsItPregnant = isItPregnant;
        }
    }
}