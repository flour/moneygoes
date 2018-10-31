using AspNetCore.Identity.Mongo.Model;

namespace moneygoes.Models
{
    public class AppUser : MongoUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}