using TravelApp.DAL.Interface;

namespace TravelApp.DAL.Repositories
{
    public class UnitOfWorkFactory: IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
