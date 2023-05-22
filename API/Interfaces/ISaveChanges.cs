namespace API.Interfaces
{
    public interface ISaveChanges:IDisposable
    {
        Task Complete();
    }
}
