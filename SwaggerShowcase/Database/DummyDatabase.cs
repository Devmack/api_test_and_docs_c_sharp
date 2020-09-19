using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwaggerShowcase.Models;

namespace SwaggerShowcase.Database
{
    public class DummyDatabase
    {
        private List<Mentor> Mentors = new List<Mentor>();

        public DummyDatabase()
        {
            Mentors.Add(new Mentor(1, "Dominik", "Starzyk", "C#", 12));
            Mentors.Add(new Mentor(2, "Daniel", "Nowak", "Java", 12));
        }


        public List<Mentor> GetAll()
        {
            return Mentors;
        }
        public Mentor GetSingleBySurname(string surname)
        {
            return Mentors.Find(mentor => mentor.Surname.Equals(surname));
        }

        public Mentor GetSingleByID(int id)
        {
            return Mentors.Find(mentor => mentor.Id == id);
        }

        public void AddMentor(Mentor mentor)
        {
            Mentors.Add(mentor);
        }

    }
}
