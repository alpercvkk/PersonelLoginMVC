namespace PersonelLoginMCVPoject.Data.Entities
{
    public class User
    {
        public string Id { get; init; } //Sadece constructordan imit olsın diye bir özellik.
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get;set; }


        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        // Kullanıcının rolleri 
        public List<Role> Roles { get; set; }
    }

    

}
