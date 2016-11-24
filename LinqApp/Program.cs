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

        static List<Pedido> CriarPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            pedidos.Add(new Pedido()
            {
                ID = 1,
                IdCliente = 1,
                Data = DateTime.Now,
                Preco = 40.0
            });
            pedidos.Add(new Pedido()
            {
                ID = 2,
                IdCliente = 1,
                Data = DateTime.Now,
                Preco = 100.90
            });
            pedidos.Add(new Pedido()
            {
                ID = 3,
                IdCliente = 2,
                Data = DateTime.Now,
                Preco = 450.0
            });
            pedidos.Add(new Pedido()
            {
                ID = 4,
                IdCliente = 3,
                Data = DateTime.Now,
                Preco = 32.1
            });
            pedidos.Add(new Pedido()
            {
                ID = 5,
                IdCliente = 3,
                Data = DateTime.Now,
                Preco = 343.52
            });
            pedidos.Add(new Pedido()
            {
                ID = 6,
                IdCliente = 4,
                Data = DateTime.Now,
                Preco = 134.98
            });
            return pedidos;
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
            List<Pedido> pedidos = CriarPedidos();

            var result = from c in clientes
                         join p in pedidos
                         on c.ID equals p.IdCliente
                         into clientesComPedidos
                         select new
                         {
                             c.Nome,
                             TotalDePedidos = clientesComPedidos.Count()
                         };

            //Em sintaxe de método ficaria da seguinte forma:
            //var result = clientes.Join(pedidos, c => c.ID, p => p.IdCliente, (cliente, pedido) => new { cliente, pedido }).GroupBy(a => a.cliente.Nome).Select(g => new { Nome = g.Key, TotalDePedidos = g.Count() });

            foreach (var item in result)
            {
                Console.WriteLine("*******************************");
                Console.WriteLine(item);
                Console.WriteLine("*******************************");
            }

            Console.ReadKey();

        }
    }

}
