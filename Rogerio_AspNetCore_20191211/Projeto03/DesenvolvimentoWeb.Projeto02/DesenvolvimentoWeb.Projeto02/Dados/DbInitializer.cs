using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public static class DbInitializer
    {
        public static void Initialize(EventosContext context)
        {
            //Método que cria o banco de dados e as tabelaas
            //Faz o Update-Database
            context.Database.EnsureCreated();
        }
    }
}
