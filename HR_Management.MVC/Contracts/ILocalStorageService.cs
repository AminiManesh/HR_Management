namespace HR_Management.MVC.Contracts
{
    public interface ILocalStorageService
    {
        void ClearLocalStorage(List<string> keys);
        bool Exists(string key);
        T GetStorageValue<T>(string key);

        void SetStorageValue<T>(string key, T value);
    }
}
