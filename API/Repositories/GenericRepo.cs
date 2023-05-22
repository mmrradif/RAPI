using Microsoft.EntityFrameworkCore;
using API.Database_Context;
using API.Interfaces;

namespace API.Repositories
{
    public class GenericRepo<T> : IAll<T> where T : class
    {
        private readonly EmployeeDbContext employeeDbContext;
        internal DbSet<T> dbSet;

        public GenericRepo(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
            this.dbSet = this.employeeDbContext.Set<T>();
        }

        public Task Complete()
        {
            try
            {
                var result = this.employeeDbContext.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            employeeDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                var result = await dbSet.ToListAsync(); 
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T entity)
        {
            try
            {
                try
                {
                    await dbSet.AddAsync(entity);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
