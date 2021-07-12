using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TestTask.Enums;

namespace Repository.Models.Customer
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(MrGreenCustomerModel), typeof(RedBetCustomerModel))]
    public abstract class CustomerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        [BsonRepresentation(BsonType.String)]
        public BrandType BrandType { get; set; }
    }
}
