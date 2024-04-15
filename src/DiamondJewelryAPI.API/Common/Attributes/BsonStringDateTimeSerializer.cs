using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace DiamondJewelryAPI.API.Common.Attributes;

public class BsonStringDateTimeSerializer : SerializerBase<DateTime>
{
    public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        return DateTime.Parse(context.Reader.ReadString());
    }
}