namespace PartsAPI.Core.Interfaces
{
    public interface IHealthRepository
    {
        Task<bool> CanConnectToDatabaseAsync();
    }
}
