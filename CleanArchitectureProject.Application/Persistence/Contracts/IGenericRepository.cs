using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProject.Application.Persistence.Contracts
{
    // Interface định nghĩa các phương thức CRUD chung cho mọi entity

    /* T -> (Generic Type): cho phải hoạt động với bất kỳ loại entity nào (Order, Product, User,...)  */

    /* where T : class -> Ràng buộc T phải là một class, " không thể " là kiểu nguyên thủy như (int, string,...)  */

    /* Các phương thức Task<T> : Dùng async/await giúp xử lý dữ liệu bất đồng bộ (async database operations) */

    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id); // Lấy 1 entity theo ID
        Task<IReadOnlyList<T>> GetAll(); // Lấy danh sách tất cả entities
        Task<T> Add(T entity); // Thêm entity vào database
        Task Update(T entity); // Cập nhật entity
        Task Delete(T entity); // Xóa entity khỏi database
        Task<bool> Exists(int id);
    }
}
