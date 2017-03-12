using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;

namespace mkcoders_ioc
{
    public class PersonSerice : IPersonService
    {
        private List<Person> people = new List<Person>();

        public bool Delete(Person person)
        {
            if (people.Remove(person))
                return true;
            return false;
        }

        public ReadOnlyCollection<Person> GetAllPeople()
        {
            return people.AsReadOnly();
        }

        public bool Update(Person person)
        {
            people.Add(person);
            return true;
        }

        public bool Delete(int person)
        {
            people.Remove(people.SingleOrDefault(p => p.Id == person));
            return true;
        }
    }
}