using IntrooApi.Models;

namespace IntrooApi.Data
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerGeneralInfoDto>> GetAllCustomers();
        Task<CustomerDetailsDto> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(Customer customer);
        Task Save();
    }
}