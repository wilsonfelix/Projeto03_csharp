using Dapper;
using Projeto03_csharp.Interfaces;
using Projeto03_csharp.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03_csharp.Repositories
{
    public class EmpresaRepository : IBaseRepository<Empresa>
    {
        //atributo
        private readonly string _connectionString = @"Data Source=SRVSQLSERVER;Initial Catalog=SQLLAB1;Integrated Security=True";
        public void Create(Empresa obj)
        {
            //escreve o comando SQL
            var sqlInsert = @"
                            INSERT INTO  EMPRESA(ID, RAZAOSOCIAL, NOMEFANTASIA, CNPJ)
                            VALUES(@Id, @RazaoSocial, @NomeFantasia, @Cnpj)
                            ";

            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sqlInsert, obj);
            }
        }

        public void Delete(Empresa obj)
        {
            //escreve o comando SQL
            var sqlDelete = @"
                            DELETE FROM EMPRESA 
                            WHERE ID = @Id
                            ";

            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sqlDelete, obj);
            }
        }

        public List<Empresa> GetAll()
        {
            //escreve o comando SQL
            var sqlSelect = @"
                            SELECT * FROM EMPRESA
                            ORDER BY NOMEFANTASIA ASC
                            ";
            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper e retornar o resultado
                return connection.Query<Empresa>(sqlSelect).ToList();
            }
        }

        public void Update(Empresa obj)
        {
            //escreve o comando SQL
            var sqlUpdate = @"
                            UPDATE EMPRESA SET RAZAOSOCIAL = @RazaoSocial, NOMEFANTASIA = @NomeFantasia, CNPJ = @Cnpj
                            WHERE ID = @Id
                            ";
            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sqlUpdate, obj);
            }
        }
    }
}
