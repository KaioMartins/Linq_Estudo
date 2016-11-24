using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    class Program
    {
        static List<Cliente> CriarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            clientes.Add(
                            new Cliente()
                            {
                                ID = 1,
                                Nome = "Felipe Mourato",
                                Sexo = Cliente.SexoEnum.Masculino,
                                Nascimento = new DateTime(1980, 12, 1),
                                Email = "felipe@contoso.com"
                            }
                        );

            clientes.Add(
                            new Cliente()
                            {
                                ID = 2,
                                Nome = "Mauro Mauricio",
                                Sexo = Cliente.SexoEnum.Masculino,
                                Nascimento = new DateTime(1970, 6, 12),
                                Email = "mauro@treinaweb.com.br"
                            }
                        );

            clientes.Add(
                            new Cliente()
                            {
                                ID = 3,
                                Nome = "Suzan Suzi",
                                Sexo = Cliente.SexoEnum.Feminino,
                                Nascimento = new DateTime(1992, 2, 25),
                                Email = "suzan@treinaweb.com.br"
                            }
                        );

            clientes.Add(
                            new Cliente()
                            {
                                ID = 4,
                                Nome = "Claudia Rodrigues",
                                Sexo = Cliente.SexoEnum.Feminino,
                                Nascimento = new DateTime(1990, 4, 3),
                                Email = "claudia@treinaweb.com.br"
                            }
                        );

            return clientes;
        }

        static void ExibirResultado(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("*******************************");
                Console.WriteLine("{0} - {1}", cliente.ID, cliente.Nome);
                Console.WriteLine("Nascimento: {0}", cliente.Nascimento);
                Console.WriteLine("Sexo: {0}", cliente.Sexo.ToString());
                Console.WriteLine("Email: {0}", cliente.Email);
                Console.WriteLine("*******************************");
                Console.WriteLine("");
            }
        }

        static void Main(string[] args)
        {
            List<Cliente> clientes = CriarClientes();

            IEnumerable<Cliente> resultado;

            resultado = from c in clientes
                        orderby c.Nome descending
                        select c;

            //Em sintaxe de método ficaria da seguinte forma:
            //resultado = clientes.OrderByDescending(c => c.Nome);

            Console.WriteLine("Ordenação:");
            ExibirResultado(resultado.ToList());

            resultado = from c in clientes
                        where c.Email.Contains("treinaweb")
                        select c;

            //Em sintace de método ficaria da seguinte forma
            //resultado = clientes.where(c => c.Email.Contains("treinaweb"));

            Console.WriteLine("Filtro:");
            ExibirResultado(resultado.ToList());

            Console.ReadKey();
        }
    }

}
