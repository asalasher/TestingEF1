using System;

namespace Domain
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Seria necesario aqui incluir la Foreign Key? o ya no lo es puesto que de las joins se ocupa entity framework?

        public override string ToString()
        {
            return $"Id: {Id} | Name:{Name} | Date of birth: {DateOfBirth}";
        }
    }

}
