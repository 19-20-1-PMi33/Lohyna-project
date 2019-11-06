using Model;
using DataServices;
using System;
using Xunit;

namespace UnitTests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
            using (var sqliteContext = new SqliteDbContext(""))
            {

            }
        }
	}
}
