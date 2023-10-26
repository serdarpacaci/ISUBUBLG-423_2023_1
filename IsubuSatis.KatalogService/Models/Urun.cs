using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IsubuSatis.KatalogService.Models
{
    public class Urun
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Ad { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Fiyat { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EklenmeTarihi { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string KategoriId { get; set; }

        [BsonIgnore]
        public Kategori KategoriFk { get; set; }

    }
}
