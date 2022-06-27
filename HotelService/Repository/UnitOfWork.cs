using System;
using System.Threading.Tasks;
using HotelService.Data;
using HotelService.IRepository;

namespace HotelService.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DatabaseContext context;
        IGenericRepository<Country> _countries;
        IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DatabaseContext context) {
            this.context = context;
        }

        public void Dispose() {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(context);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(context);

        public async Task Save() {
            await context.SaveChangesAsync();
        }
    }
}