using MySql.Data.MySqlClient;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealth.Dados
{
    public class acoesPagamento
    {
        Conexao con = new Conexao();
        public void inserirPagamento(modelPagamento cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPagamento values(default, @numeroCartao, @nomeCartao)", con.MyConectarBD());

            cmd.Parameters.Add("@numeroCartao", MySqlDbType.VarChar).Value = cm.numeroCartao;
            cmd.Parameters.Add("@nomeCartao", MySqlDbType.VarChar).Value = cm.nomeCartao;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}