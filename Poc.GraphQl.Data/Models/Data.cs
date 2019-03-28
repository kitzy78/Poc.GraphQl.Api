using System;

namespace Poc.GraphQl.Data.Models
{
    public class Data
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Data()
            : this(Guid.NewGuid().ToString())
        {
        }

        public Data(string id)
        {
            Id = Guid.Parse(id);
            var randomizer = new Random(DateTime.Now.Millisecond);
            var length = Math.Max(1, randomizer.Next((int)'Z' - (int)'A')) + (int)'A';
            for (var i = (int)'A'; i < length; i++)
            {
                Description = $"{Description}{(char)i}";
            }
        }
    }
}
