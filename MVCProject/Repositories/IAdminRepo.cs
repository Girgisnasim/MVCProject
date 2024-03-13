using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface IAdminRepo
    {
        public List<Trip> Getall();
        public Trip Get(int id);
        public void Add(Trip trip);
        public void Update(Trip trip);
        public void Delete(int id);

    }
}
