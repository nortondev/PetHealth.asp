using MySql.Data.MySqlClient;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealth.Dados
{
    public class acoesLogin
    {
        Conexao con = new Conexao();

        public void TestarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where Usuario = @Usuario and Senha = @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = user.Usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.Senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.Usuario = Convert.ToString(leitor["Usuario"]);
                    user.Senha = Convert.ToString(leitor["Senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }

            else
            {
                user.Usuario = null;
                user.Senha = null;
                user.tipo = null;
            }

            con.MyDesconectarBD();
        }

        public void CadastrarUsuario(modelLogin cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLogin values(default, @nomeUsuario, @sobrenomeUsuario, @cpf, @Usuario, @Senha, 1);", con.MyConectarBD());

            cmd.Parameters.Add("@nomeUsuario", MySqlDbType.VarChar).Value = cm.nomeUsuario;
            cmd.Parameters.Add("@sobrenomeUsuario", MySqlDbType.VarChar).Value = cm.sobrenomeUsuario;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cm.cpf;
            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = cm.Usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cm.Senha;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}