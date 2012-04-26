using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess;
using PickAWinnerTDD.Domain;
using StructureMap;

namespace PickAWinnerTDD.UI {

    public class StructureMapBootstrapper {

        public static void BootstrapStructureMap() {
            // Initialize the static ObjectFactory container
            ObjectFactory.Initialize(x => { x.For<IAttendee>().Use<Attendee>();
                                         x.For<ISponsor>().Use<Sponsor>();
                                         x.For<ISwag>().Use<Swag>();
                                         x.For<IWinner>().Use<Winner>();
                                         x.For<IAttendeeRepository>().Use<AttendeeRepository>();
                                         x.For<ISponsorRepository>().Use<SponsorRepository>();
                                         x.For<ISwagRepository>().Use<SwagRepository>();
                                         x.For<IWinnerRepository>().Use<WinnerRepository>();
                                     });
        }
    }
}
