using Microsoft.EntityFrameworkCore;
using API.Database_Context;
using API.Database_Models;
using API.Repositories;

namespace PracticalAPI.Repositories
{
    public class EmployeeRepo : GenericRepo<Employee>
    {
        public EmployeeRepo(EmployeeDbContext employeeDbContext) : base(employeeDbContext)
        {
        }

        public override async Task<Employee> GetById(int id)
        {
            try
            {
                var result = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override async Task<bool> Update(Employee employee)
        {
            try
            {
                var existingData = await GetById(employee.Id);
                if (existingData != null)
                {
                    existingData.Id = employee.Id;
                    existingData.Name = employee.Name;
                    existingData.JoiningDate = employee.JoiningDate;
                    existingData.Salary = employee.Salary;
                    existingData.IsManager = employee.IsManager;

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public override async Task<bool> Delete(int id)
        {
            try
            {
                var existingData = await GetById(id);
                if (existingData != null)
                {
                    dbSet.Remove(existingData);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
