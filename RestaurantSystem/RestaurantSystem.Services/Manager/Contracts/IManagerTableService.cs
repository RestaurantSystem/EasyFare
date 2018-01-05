namespace RestaurantSystem.Services.Manager.Contracts
{
    using System.Threading.Tasks;

    public interface IManagerTableService
    {
        Task<bool> TableAlreadyExist(string number);

        Task<bool> AddNewTableAsync(string number, int seats, int sectioId);
    }
}