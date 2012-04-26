using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.Domain;
using PickAWinnerTDD.Domain.Tests.Unit.Stubing.Stubs.Repository;
using PickAWinnerTDD.UnitTesting.Stubs.DataAccess;
using PickAWinnerTDD.UnitTesting.Stubs.Domain;
using StructureMap;

namespace PickAWinnerTDD.UnitTesting.Stubs {

    public class StructureMapBootstrapperStub {

        public static void BootstrapStructureMap() {
            // Initialize the static ObjectFactory container
            ObjectFactory.Initialize(x => { x.For<IAttendee>().Use<AttendeeStub>();
                                         x.For<ISponsor>().Use<SponsorStub>();
                                         x.For<ISwag>().Use<Swag>();
                                         x.For<IWinner>().Use<Winner>();
                                         x.For<IAttendeeRepository>().Use<AttendeeRepositoryStub>();
                                         x.For<ISponsorRepository>().Use<SponsorRepositoryStub>();
                                         x.For<ISwagRepository>().Use<SwagRepositoryStub>();
                                         x.For<IWinnerRepository>().Use<WinnerRepositoryStub>();
                                     });
        }
    }
}
