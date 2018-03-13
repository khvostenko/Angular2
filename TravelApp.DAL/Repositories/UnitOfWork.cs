using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;
using TravelApp.DAL.Context;

namespace TravelApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TravelContext context = new TravelContext();
        private IGenericRepository<Administrator> administratorRepository;
        private IGenericRepository<User> userRepository;
        private IGenericRepository<Person> personRepository;
        private IGenericRepository<City> cityRepository;
        private IGenericRepository<Photo> photoRepository;
        private IGenericRepository<Comment> commentRepository;
        private IGenericRepository<CitiesWhichIVisited> citiesWhichIVisitedRepository;
        private IGenericRepository<CitiesWhichIWantToVisit> citiesWhichIWantToVisitRepository;
        private IGenericRepository<CityVisitedPerson> citiesVisitedPersonRepository;
        private IGenericRepository<CityWantPerson> citiesWantPersonRepository;

        public IGenericRepository<Administrator> AdministratorRepository
        {
            get
            {
                if(administratorRepository==null)
                {
                    administratorRepository = new GenericRepository<Administrator>(context);
                }
                return administratorRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if(userRepository==null)
                {
                    userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public IGenericRepository<Person> PersonRepository
        {
            get
            {
                if(personRepository==null)
                {
                    personRepository = new GenericRepository<Person>(context);
                }
                return personRepository;
            }
        }

        public IGenericRepository<City> CityRepository
        {
            get
            {
                if(cityRepository==null)
                {
                    cityRepository = new GenericRepository<City>(context);
                }
                return cityRepository;
            }
        }

        public IGenericRepository<Photo> PhotoRepository
        {
            get
            {
                if(photoRepository==null)
                {
                    photoRepository = new GenericRepository<Photo>(context);
                }
                return photoRepository;
            }
        }

        public IGenericRepository<Comment> CommentRepository
        {
            get
            {
                if(commentRepository==null)
                {
                    commentRepository = new GenericRepository<Comment>(context);
                }
                return commentRepository;
            }
        }

        public IGenericRepository<CitiesWhichIVisited> CitiesWhichIVisitedRepository
        {
            get
            {
                if(citiesWhichIVisitedRepository==null)
                {
                    citiesWhichIVisitedRepository = new GenericRepository<CitiesWhichIVisited>(context);
                }
                return citiesWhichIVisitedRepository;
            }
        }

        public IGenericRepository<CitiesWhichIWantToVisit> CitiesWhichIWantToVisitRepository
        {
            get
            {
                if(citiesWhichIWantToVisitRepository==null)
                {
                    citiesWhichIWantToVisitRepository = new GenericRepository<CitiesWhichIWantToVisit>(context);
                }
                return citiesWhichIWantToVisitRepository;
            }
        }

        public IGenericRepository<CityVisitedPerson> CityVisitedPersonRepository
        {
            get
            {
                if(citiesVisitedPersonRepository==null)
                {
                    citiesVisitedPersonRepository = new GenericRepository<CityVisitedPerson>(context);
                }
                return citiesVisitedPersonRepository;
            }
        }

        public IGenericRepository<CityWantPerson> CityWantPersonRepository
        {
            get
            {
                if (citiesWantPersonRepository == null)
                {
                    citiesWantPersonRepository = new GenericRepository<CityWantPerson>(context);
                }
                return citiesWantPersonRepository;
            }
        }

        public void Dispose()
        {
            context.Dispose();
            System.GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
