using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mkcoders_ioc
{
    class MainProgram
    {
        static void Main(String[] args)
        {
            
        }
    }

    [TestFixture]
    class Program
    {
        [Test]
        public void TestCoupledClass()
        {
            PersonSerice personSerice = new PersonSerice();
            FullDecoupledClass myCoupledClass = new FullDecoupledClass(personSerice);
            myCoupledClass.run();
        }

        [Test]
        public void TestDeCoupledClass()
        {
            MkCoderInjector injector = new MkCoderInjector();
            injector.bind<IPersonService, PersonSerice>();            
            FullDecoupledClass myCoupledClass = injector.resolve<FullDecoupledClass>();
            myCoupledClass.run();
        }
    }
}
