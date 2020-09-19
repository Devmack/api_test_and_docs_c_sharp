using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerShowcase.Models
{
    public class Mentor
    {
        /// <summary>
        /// Number based identifier used to distinguish and fetch unique records 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Any name that you can think of 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Text based identifier 
        /// </summary>
        /// <example>
        /// "Starzyk"
        /// </example>
        public string Surname { get; set; }

        /// <summary>
        /// Text value that determines main area of expertise for given mentor
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Number based indicator that describes how old mentors are
        /// </summary>
        public int Age { get; set; }

        public Mentor(int id, string name, string surname, string specialization, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialization = specialization;
            Age = age;
        }

        public Mentor()
        {
        }
    }
}
