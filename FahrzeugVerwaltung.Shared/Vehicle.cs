using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FahrzeugVerwaltung.Shared
{
    public abstract class Vehicle
    {
        internal Vehicle(int id, VehicleType vehicleType, string brand, string model)
        {
            this.Id = id;
            this.VehicleType = vehicleType;
            this.Brand = brand;
            this.Model = model;
            this.Color = "Transparent";
            this.Seats = -1;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public override string ToString()
        {
            return String.Format("\u001b[36mIdent: {0}, Typ:\u001b[34m{1}\u001b[36m, Marke: {2}, Modell: {3}\u001b[0m", Id, VehicleType, Brand, Model);
        }

        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }
    }

    public class VehicleJsonConverter : JsonConverter<Vehicle>
    {
        public override Vehicle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var id = -1;
            var type = VehicleType.PKW;
            var brand = "NoBrand";
            var model = "NoModel";
            var capacity = Double.NaN;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    switch (type)
                    {
                        case VehicleType.PKW:
                            return new PKW(id, brand, model);
                        case VehicleType.LKW:
                            return new LKW(id, brand, model, capacity);
                        default:
                            throw new JsonException("Unknown Type! That should not happen!");
                    }
                }
                if(reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }
                var property = reader.GetString();
                reader.Read();
                switch (property)
                {
                    case "Id":
                        id = reader.GetInt32();
                        break;
                    case "VehicleType":
                        type = (VehicleType) reader.GetByte();
                        break;
                    case "Brand":
                        brand = reader.GetString();
                        break;
                    case "Model":
                        model = reader.GetString();
                        break;
                    case "Capacity":
                        capacity = reader.GetDouble();
                        break;
                }
            }
            throw new JsonException("Expected Propertiy but found EOF");
        }

        public override void Write(Utf8JsonWriter writer, Vehicle value, JsonSerializerOptions options)
        {
            Console.WriteLine("Writing...");
            writer.WriteStartObject();
            writer.WriteNumber("Id", value.Id);
            writer.WriteNumber("VehicleType", (int) value.VehicleType);
            writer.WriteString("Brand", value.Brand);
            writer.WriteString("Model", value.Model);
            if(value.VehicleType == VehicleType.LKW)
            {
                writer.WriteNumber("Capacity", ((LKW) value).Capacity);
            }
            writer.WriteEndObject();
        }
    }

    public class PKW : Vehicle
    {
        public PKW(int id, string brand, string model) : base(id, VehicleType.PKW, brand, model)
        {

        }
    }

    public class LKW : Vehicle
    {
        public LKW(int id, string brand, string model, double capacity) : base(id, VehicleType.LKW, brand, model)
        {
            Capacity = capacity;
        }
        public override string ToString()
        {
            return String.Format("\u001b[36mIdent: {0}, Typ:\u001b[33m{1}\u001b[36m, Marke: {2}, Modell: {3}, FrachtKapazität: {4}\u001b[0m", Id, VehicleType, Brand, Model, Capacity);
        }
        
        public double Capacity { get; set; }
    }
}
