﻿using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ICustomerRepo
    {
        //show all booking ticket for this customer
        public List<Ticket> GetAll();
        //Delete ticket
        public void Delete(int id);

    }
}