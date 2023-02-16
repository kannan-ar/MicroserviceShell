using MongoDB.Driver;
using Shell.API.Domain.Repositories;
using System.Threading.Tasks;

namespace Shell.API.Infrastructure.Repositories
{
    public class MongoDbUnitOfWork : IUnitOfWork
    {
        private readonly IMongoClient _mongoClient;
        private readonly IRowRepository _rowRepository;
        private readonly IPageRepository _pageRepository;
        private readonly IComponentRepository _componentRepository;

        private IClientSessionHandle session;

        public MongoDbUnitOfWork(
            IMongoClient client, 
            IRowRepository rowRepository, 
            IPageRepository pageRepository,
            IComponentRepository componentRepository)
        {
            _mongoClient = client;
            _rowRepository = rowRepository;
            _pageRepository = pageRepository;
            _componentRepository = componentRepository;
        }

        public IPageRepository PageRepository => _pageRepository;

        public IRowRepository RowRepository => _rowRepository;

        public IComponentRepository ComponentRepository => _componentRepository;

        public async Task BeginTransactionAsync()
        {
            session = await _mongoClient.StartSessionAsync();
            session.StartTransaction();
        }

        public async Task CommitChangesAsync()
        {
            await session?.CommitTransactionAsync();
            session = null;
        }

        public async Task RollbackChangesAsync()
        {
            await session?.AbortTransactionAsync();
            session = null;
        }
    }
}
