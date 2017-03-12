using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace mkcoders_ioc
{
    public interface IPersonService
    {
        ReadOnlyCollection<Person> GetAllPeople();
        bool Update(Person person);
        bool Delete(Person person);
        bool Delete(int person);
    }
}