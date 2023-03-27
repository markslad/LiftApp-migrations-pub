using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftApp.Dal.Tests.Extensions;
using LiftApp.Dal.Contexts;
using LiftApp.Dal.Models;
using FluentAssertions;
using Xunit;
using LiftApp.Dal.Interfaces;

namespace LiftApp.Dal.Tests.Contexts
{
    internal class UnitOfWorkContext
    {
        private IServiceProvider _serviceProvider;
        private IMainUnitOfWork _unitOfWork;

        public UnitOfWorkContext()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterServicesForDbContextTesting();
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _unitOfWork = _serviceProvider.GetRequiredService<IMainUnitOfWork>();
        }

        internal async Task Given_Office_And_Address(Office office, Address address)
        {
            await _unitOfWork.AddressRepository.InsertAsync(address);
            await _unitOfWork.OfficeRepository.InsertAsync(office);
            await _unitOfWork.SaveChangesAsync();
        }

        internal async Task When_Lift_Is_Added_Into_Database(Lift lift)
        {
            await _unitOfWork.LiftRepository.InsertAsync(lift);
            await _unitOfWork.SaveChangesAsync();
        }

        internal async Task Then_Read_Lift_Is_Equal(Lift expectedLift)
        {
            //var lifts = await _unitOfWork.LiftRepository.GetAsync(includeProperties: $"Office");
            //var lift = lifts.Single();
            //lift.MaximumHeight = 15;
            //lift.Should().Be(expectedLift);
        }
    }
}
