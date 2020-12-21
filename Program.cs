using Refit;
using System;
using System.Threading.Tasks;

namespace ConsumoApiRefit_Net5_0
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await ConsumoDireto();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro na consulta ao cep: " + ex.Message);
            }

            static async Task ConsumoDireto()
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu cep:");

                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Cep informado:" + cepInformado);

                var address = await cepClient.GetAdressAsync(cepInformado);

                Console.WriteLine($"\n {address.Logradouro} \n {address.Bairro} \n {address.Localidade}");

                Console.ReadLine();
            }
        }
    }
}
