using System;
namespace LiteDbDemo
{
	public record Person
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string Company { get; set; }
	}
}

