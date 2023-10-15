using ShoppingCart.Data.Models;

namespace ShoppingCart.API.Services
{
    public interface IDepartment
    {
        Task<(int, string)> AddDepartment(string department);

        Task<(int, string)> DeleteDepartment(int departmentId);

        Task<(int, string)> UpdateDepartment(int id, string department);

        Task<List<DepartmentModel>> GetAllDepartments();

        Task<DepartmentModel> GetDepartmentById(int departmentId);
    }
}