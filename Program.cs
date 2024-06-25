using System;
using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;

class Program
{
    static void Main(string[] args)
    {

        string connectionString = "mongodb://localhost:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("LB-M165");

        var collection = database.GetCollection<BsonDocument>("Worldcup_Data_Test");


        // Create
        var document = new BsonDocument { { "name", "John Doe" }, { "age", 20 } };
        collection.InsertOne(document);

        // Read
        var filter = Builders<BsonDocument>.Filter.Eq("name", "John Doe");
        var result = collection.Find(filter).FirstOrDefault();
        Console.WriteLine(result.ToString());

        // Update
        var update = Builders<BsonDocument>.Update.Set("age", 200);
        collection.UpdateOne(filter, update);

        Console.WriteLine(result.ToString());

        // Delete
        collection.DeleteOne(filter);
        Console.WriteLine(result.ToString());


    }
}