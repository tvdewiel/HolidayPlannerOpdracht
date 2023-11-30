namespace HolidayPlannerREST.Model.Output
{
    public class CustomerRESTOutputDTO
    {
        public CustomerRESTOutputDTO(int id, string name, string address, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
