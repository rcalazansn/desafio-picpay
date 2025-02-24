namespace desafio.api.Services.Interfaces
{
    public interface IAutorizadorService
    {
        Task<bool> AuthorizeAsync();
    }
}
