namespace PersonelLoginMCVPoject.Data.Entities
{
    public class Role
    {
        public string Id { get; init; }

        public string Name { get; set; }

        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }

        public List<User> Users { get; set; }
    }
}