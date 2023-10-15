using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Models;

namespace ShoppingCart.API.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<(int, string)> AddDepartment(string department)
        {
            try
            {
                await _context.Departments.AddAsync(new DepartmentModel
                {
                    DepartmentName = department,
                    ModifiedDate = DateTime.Now,
                });
                return (await _context.SaveChangesAsync(), "Department Add Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(int, string)> DeleteDepartment(int departmentId)
        {
            try
            {
                var department = await _context.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefaultAsync();
                _context.Departments.Remove(department);
                return (await _context.SaveChangesAsync(), "Department Delete Successfully");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<DepartmentModel> GetDepartmentById(int departmentId)
        {
            return await _context.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefaultAsync();
        }

        public async Task<(int, string)> UpdateDepartment(int id, string department)
        {
            try
            {
                var departmentmodel = await _context.Departments.Where(x => x.DepartmentId == id).FirstOrDefaultAsync();
                if (departmentmodel != null)
                {
                    departmentmodel.ModifiedDate = DateTime.Now;
                    departmentmodel.DepartmentName = department;
                    return (await _context.SaveChangesAsync(), "Department Update Successfully");
                }
                return (0, "Department Updated Failed");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}