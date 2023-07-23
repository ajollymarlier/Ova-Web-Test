using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;


namespace OvaWebTest.Application.DTOs
{
    [BsonIgnoreExtraElements]
    public class UserDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [BsonElement("userName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [BsonElement("lastName")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
