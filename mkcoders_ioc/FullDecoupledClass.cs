using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkcoders_ioc
{
    public class FullDecoupledClass
    {
        private IPersonService personService;

        public FullDecoupledClass(IPersonService personService)
        {
            this.personService = personService;
        }

        public void run()
        {
            personService.Update(new Person() {Id = 1, FavoriteColor = "Orange", Name = "James OsWell"});
            personService.Update(new Person() {Id = 2, FavoriteColor = "Red", Name = "Joe Smith"});
            personService.Update(new Person() {Id = 3, FavoriteColor = "Blue", Name = "Emily Rogers"});

            Console.WriteLine(" add all the items to my personService\n\n");
            foreach (var person in personService.GetAllPeople())
            {
                Console.WriteLine(person);
            }

            personService.Update(new Person() {Id = 4, Name = "Joe Bloe", FavoriteColor = "Green"});
            Console.WriteLine("\nupdate the items to my personService\n");
            foreach (var person in personService.GetAllPeople())
            {
                Console.WriteLine(person);
            }
            personService.Delete(1);

            Console.WriteLine("\ndelete the items to my personService\n");
            foreach (var person in personService.GetAllPeople())
            {
                Console.WriteLine(person);
            }
        }

    }
}
