using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramacaoAssincrona
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarAsync().Wait();
            Console.ReadKey();
        }

        static async Task AguardarAsync()
        {
            Console.WriteLine("Aguardando...");
            await Task.Delay(5000);
        }

        static async Task MostrarAsync()
        {
            await AguardarAsync();
            Console.WriteLine($"Hora atual: {DateTime.Now.TimeOfDay:t}");
        }
    }
}
