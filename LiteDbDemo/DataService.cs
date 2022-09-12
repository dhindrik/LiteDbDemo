using System;
using LiteDB;

namespace LiteDbDemo
{
	public class DataService : IDataService
	{
        private const string personsDataCollectionName = "persons";
        private readonly ISecureStorageService secureStorageService;

        public DataService(ISecureStorageService secureStorageService)
		{
            this.secureStorageService = secureStorageService;
        }

        public async Task<List<Person>> GetAll()
        {
            using var db = new LiteDatabase(await GetConnectionString());

            var collection = db.GetCollection<Person>(personsDataCollectionName);

            var persons = collection.Query().ToList();

            return persons;
        }

        public async Task Save(Person person)
        {
            using var db = new LiteDatabase(await GetConnectionString());

            var collection = db.GetCollection<Person>(personsDataCollectionName);

            collection.Insert(person);

            collection.EnsureIndex(x => x.Name);
        }

        public async Task<string> Upload(byte[] bytes, string filename)
        {
            using var db = new LiteDatabase(await GetConnectionString());

            var info = db.FileStorage.Upload(Guid.NewGuid().ToString(), filename, new MemoryStream(bytes));

            return info.Id;
        }

        public async Task<byte[]> Download(string id)
        {
            using var db = new LiteDatabase(await GetConnectionString());

            var stream = new MemoryStream();

            db.FileStorage.Download(id, stream);

            stream.Position = 0;

            return stream.ToArray();
        }

        private async Task<string> GetConnectionString()
        {
            var path = FileSystem.Current.AppDataDirectory;

            var fullPath = Path.Combine(path, "persons.db");

            var password = await secureStorageService.Get("password");

            if(password == null)
            {
                password = Guid.NewGuid().ToString();
                await secureStorageService.Save("password", password);
            }

            var connectionString = $"Filename={fullPath};Password={password}";

            return connectionString;

            
        }
    }
}

