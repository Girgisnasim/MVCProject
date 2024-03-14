using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface IPlanRepo
    {

        public List<Plan> Getall();
        public Plan Get(int id);
        public void Add(Plan plan);
        public void Update(Plan plan);
        public void Delete(int id);


    }
}
