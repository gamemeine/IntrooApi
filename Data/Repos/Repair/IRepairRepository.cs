using IntrooApi.Models;

namespace IntrooApi.Data
{
    public interface IRepairRepository
    {
        Task<IEnumerable<RepairGeneralInfoDto>> GetAllRepairs();
        Task<RepairDetailsDto> GetRepairById(int id);
        Task AddRepair(Repair repair);
        Task DeleteRepair(int id);
        Task UpdateRepair(Repair repair);
        Task Save();
    }
}