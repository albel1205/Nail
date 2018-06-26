namespace Infrastructure.Serialization
{
    using System.IO;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    public class JsonTextSerializer : ITextSerializer
    {
        private readonly JsonSerializer serializer;

        public JsonTextSerializer()
            : this(JsonSerializer.Create(new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            }))
        {
        }

        public JsonTextSerializer(JsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public object Deserialize(TextReader reader)
        {
            try
            {
                var jsonReader = new JsonTextReader(reader);
                return this.serializer.Deserialize(jsonReader);
            }
            catch (JsonSerializationException ex)
            {
                throw new SerializationException(ex.Message, ex);
            }
        }

        public void Serialize(TextWriter writer, object graph)
        {
            var jsonWriter = new JsonTextWriter(writer);

            this.serializer.Serialize(jsonWriter, graph);

            writer.Flush();
        }
    }
}
