using ClientesAPI.Integration.ViaCepAPI.Response;
using Refit;

namespace ClientesAPI.Integration.ViaCepAPI.Refit
{
    public interface IViaCep
    {
        [Get("/ws/{cep}/json")]
        Task<ViaCepResponse?> GetByCep(string cep);
    }
}
