using Projeto03_csharp.Interfaces;
using Projeto03_csharp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Projeto03_csharp.Repositories
{
    /// <summary>
    /// Classe de repositorio de dados para a entidade Funcionario
    /// </summary>
    public class FuncionarioRepository : IBaseRepository<FuncionarioRepository>
    {
        private readonly string _connectionString = @"Data Source=SRVSQLSERVER;Initial Catalog=SQLLAB1;Integrated Security=True";
        public void Create(FuncionarioRepository obj)
        {
            //escreve o comando SQL
            var sqlInsert = @"
                            INSERT INTO  FUNCIONARIO (ID, NOME, MATRICULA, CPF, DATAADMISSAO, EMPRESAID)
                            VALUES(@Id, @Nome, @Matricula, @Cpf, @DataAdmissao, @EmpresaId)
                            ";

            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sqlInsert, obj);
            }
        }

        public void Delete(FuncionarioRepository obj)
        {
            //escreve o comando SQL
            var sqlDelete = @"
                            DELETE FROM FUNCIONARIO
                            WHERE ID = @Id
                            ";

            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sqlDelete, obj);
            }
        }

        public List<Funcionario> GetAll()
        {
            //escreve o comando SQL
            var sqlSelect = @"
                            SELECT * FROM FUNCIONARIO
                            WHERE ID = @Id
                            ORDER BY NOME ASC
                            ";
            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper e retornar o resultado
                return connection.Query<Funcionario>(sqlSelect).ToList();
            }
        }

        public void Update(FuncionarioRepository obj)
        {
            //escreve o comando SQL
            var sqlUpdate = @"
                            UPDATE FUNCIONARIO SET ID = @Id, NOME = @Nome, MATRICULA = @Matricula, CPF = @Cpf, DATAADMISSAO = @DataAdmissao, EMPRESAID = @EmpresaId
                            WHERE ID = @Id
                            ";

            //abrindo conexão com o sqlserver
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando com Dapper
                connection.Execute(sqlUpdate, obj);
            }
        }

        List<FuncionarioRepository> IBaseRepository<FuncionarioRepository>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
