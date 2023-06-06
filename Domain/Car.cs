namespace Domain
{

    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        // Seria necesario aqui incluir la Foreign Key? o ya no lo es puesto que de las joins se ocupa entity framework?
        public int IdOwner { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Model:{Model} | IdOwner: {IdOwner}";
        }
    }


}
