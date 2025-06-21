using ClientesAPI.Integration.ViaCepAPI.Response;
using Refit;

namespace ClientesAPI.Integration.ViaCepAPI.Refit
{
    public class ViaCep : IViaCep
    {
        private readonly IViaCep _viaCep;
        public ViaCep(IViaCep viaCep)
        {
            _viaCep = viaCep;
        }
        public async Task<ViaCepResponse?> GetByCep(string cep)
        {
            var dataCep = await _viaCep.GetByCep(cep);

            if (dataCep != null)
            {
                return dataCep;
            }

            return null;
        }
    }
}
