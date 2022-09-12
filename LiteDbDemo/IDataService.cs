using System;
namespace LiteDbDemo
{
	public interface IDataService
	{
		Task Save(Person person);
		Task<List<Person>> GetAll();
	}
}

