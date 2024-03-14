using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Repositories
{
    public class PlanRepo : IPlanRepo
    {
        BookContext Context;
        public PlanRepo(BookContext context )
        {
            Context = context;
        }


        public List<Plan> Getall()
        {
            return Context.plan.Include(e => e.Employee).ToList();
        }




        public Plan Get(int id)
        {
            return Context.plan.SingleOrDefault(x => x.Id == id);
        }
        public void Add(Plan plan)
        {
            Context.plan.Add(plan);
            Context.SaveChanges();
        }


        public void Update(Plan plan)
        {
            Context.plan.Update(plan);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Plan plan = Context.plan.SingleOrDefault(t => t.Id == id);
            Context.plan.Remove(plan);
            Context.SaveChanges();
        }
    }
}
