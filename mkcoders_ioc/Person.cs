using System;

namespace mkcoders_ioc
{
    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String FavoriteColor { get; set; }

        public override string ToString()
        {
            return $"{Id} ------ {Name} ------- {FavoriteColor}";
        }
    }
}