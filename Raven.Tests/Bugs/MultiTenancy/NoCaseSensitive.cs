using Raven.Client.Document;
using Raven.Client.Extensions;
using Xunit;

namespace Raven.Tests.Bugs.MultiTenancy
{
	public class NoCaseSensitive : RemoteClientTest
	{
		[Fact]
		public void CanAccessDbUsingDifferentNames()
		{
			using (GetNewServer())
			{
				using (var documentStore = new DocumentStore
				{
					Url = "http://localhost:8080"
				})
				{
					documentStore.Initialize();
					documentStore.DatabaseCommands.EnsureDatabaseExists("repro");
					using (var session = documentStore.OpenSession("repro"))
					{
						session.Store(new Foo
						{
							Bar = "test"
						});
						session.SaveChanges();
					}

					using (var session = documentStore.OpenSession("Repro"))
					{
						Assert.NotNull(session.Load<Foo>("foos/1"));
					}
				}
			}
		}


		internal class Foo
		{
			public string Bar { get; set; }
		}
	}
}