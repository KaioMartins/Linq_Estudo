using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string diretorio = System.Environment.SystemDirectory;
            Console.WriteLine(diretorio);

            DirectoryInfo dirInfo = new DirectoryInfo(diretorio);

            var arquivos = dirInfo.GetFiles("*.*").ToList();

            var agrupado = from a in arquivos
                           group a by a.Extension into fgroup
                           orderby fgroup.Key
                           select fgroup;

            //Em sintaxe de método ficaria da seguinte forma:
            //var agrupado = arquivos.GroupBy(a => a.Extension).OrderBy(a => a.Key);

            foreach (var filegroup in agrupado)
            {
                Console.WriteLine("{0} - {1} arquivo(s)", filegroup.Key, filegroup.Count());

                foreach (var file in filegroup)
                {
                    Console.WriteLine(file.Name);
                }
                Console.WriteLine("");
            }
            Console.ReadKey();

        }
    }

}
