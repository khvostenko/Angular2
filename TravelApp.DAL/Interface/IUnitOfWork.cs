using TravelApp.DAL.Models;

namespace TravelApp.DAL.Interface
{
    public interface IUnitOfWork:System.IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<City> CityRepository { get; }
        IGenericRepository<Photo> PhotoRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<CitiesWhichIVisited> CitiesWhichIVisitedRepository { get; }
        IGenericRepository<CitiesWhichIWantToVisit> CitiesWhichIWantToVisitRepository { get; }
        IGenericRepository<Administrator> AdministratorRepository { get; }
        IGenericRepository<CityVisitedPerson> CityVisitedPersonRepository { get; }
        IGenericRepository<CityWantPerson> CityWantPersonRepository { get; }
        void Save();
    }
}
