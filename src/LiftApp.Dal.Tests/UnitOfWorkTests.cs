using LiftApp.Dal.Models;
using LiftApp.Dal.Tests.Contexts;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftApp.Dal.Tests
{
    public class UnitOfWorkTests : FeatureFixture
    {
        [Scenario]
        public async Task TestAddingLift()
        {
            var address = new Address()
            {
                Street = "dsasdas",
                City = "dsdas",
                Country = "dsassad",
                ZipCode = "123475",
                HouseNumber = 1,
            };
            var office = new Office()
            {
                Address = address,
            };
            var lift = new Lift()
            {
                SerialNumber = "1231",
                Office = office,
                Manufacturer = "dsdasdas",
                MaximumHeight = 12,
                PowerSource = Enums.PowerSource.Diesel,
                Eliminated = false
            };

            await Runner.WithContext<UnitOfWorkContext>()
                .AddAsyncSteps(
                    _ => _.Given_Office_And_Address(office, address),
                    _ => _.When_Lift_Is_Added_Into_Database(lift),
                    _ => _.Then_Read_Lift_Is_Equal(lift)
                )
                .RunAsync();

        }
    }


    //public class TestAddingLiftData : IEnumerable<object[]>
    //{
    //    public IEnumerator<object[]> GetEnumerator()
    //    {
    //        yield return new object[] { 1, 2, 3 };
    //        yield return new object[] { -4, -6, -10 };
    //        yield return new object[] { -2, 2, 0 };
    //        yield return new object[] { int.MinValue, -1, int.MaxValue };
    //    }

    //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    //}
}
