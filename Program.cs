using Projeto03_csharp.Entities;
using Projeto03_csharp.Repositories;
using System;

namespace Projeto03_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n *** CONTROLE DE EMPRESAS *** \n");

            try
            {
                Console.WriteLine("(1) CADASTRAR EMPRESA");
                Console.WriteLine("(2) ATUALIZAR EMPRESA");
                Console.WriteLine("(3) EXCLUIR EMPRESA");
                Console.WriteLine("(4) CONSULTAR EMPRESAS");

                Console.Write("Informe a opção desejada...: ");
                var opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("\nCADASTRO DE EMPRESA:\n");

                    var empresa = new Empresa();
                    empresa.Id = Guid.NewGuid();

                    Console.WriteLine("Informe o Nome Fantasia.....: ");
                    empresa.NomeFantasia = Console.ReadLine();

                    Console.WriteLine("Informe a Razão Social......: ");
                    empresa.RazaoSocial = Console.ReadLine();

                    Console.WriteLine("Informe o CNPJ..............: ");
                    empresa.Cnpj = Console.ReadLine();

                    var empresaRepository = new EmpresaRepository();
                    empresaRepository.Create(empresa);

                    Console.WriteLine("\nEMPRESA CADASTRADA COM SUCESSO!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nERRO: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
