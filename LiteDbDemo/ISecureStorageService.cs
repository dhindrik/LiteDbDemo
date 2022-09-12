using System;

namespace LiteDbDemo
{
	public interface ISecureStorageService
	{

		Task Save(string key, string value);
		Task<string> Get(string key, string defaultValue = null);

    }
}

