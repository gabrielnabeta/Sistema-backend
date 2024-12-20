using MySql.Data.MySqlClient;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositorys {
    public class ProdutoRepository {
        private string _connectionString;

        public ProdutoRepository(string connectionString) {
            _connectionString = connectionString;
        }

        public int Inserir(Produto produto) {
            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "INSERT INTO produto (nome, codigo, preco, qtdeEstoque) VALUES (@nome, @codigo, @preco, @qtdeEstoque)";

            cmd.Parameters.AddWithValue("nome", produto.Nome);
            cmd.Parameters.AddWithValue("codigo", produto.Codigo);
            cmd.Parameters.AddWithValue("preco", produto.Preco);
            cmd.Parameters.AddWithValue("qtdeEstoque", produto.QtdeEstoque);

            cnn.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }

        public Produto ObterPorCodigo(string codigo) {
            Produto usuario = null;

            var cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM produto WHERE codigo = @codigo";

            cmd.Parameters.AddWithValue("codigo", codigo);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read()) {
                usuario = new Produto();
                usuario.Id = Convert.ToInt32(reader["id"]);
                usuario.Nome = reader["nome"].ToString();
                usuario.Codigo = reader["codigo"].ToString();
                usuario.Preco = Convert.ToDecimal(reader["preco"]);
                usuario.QtdeEstoque = Convert.ToInt32(reader["qtdeEstoque"]);
            }

            cnn.Close();

            return usuario;
        }
    }
}