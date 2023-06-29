using MySql.Data.MySqlClient;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PetHealth.Dados
{
    public class acoesCliente
    {
        Conexao con = new Conexao();

        public void inserirCliente(modelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbCliente values(default, @nomeCliente, @sobrenomeCliente, @emailCliente, @telefoneCliente)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeCliente", MySqlDbType.VarChar).Value = cm.nomeCliente;
            cmd.Parameters.Add("@sobrenomeCliente", MySqlDbType.VarChar).Value = cm.sobrenomeCliente;
            cmd.Parameters.Add("@emailCliente", MySqlDbType.VarChar).Value = cm.emailCliente;
            cmd.Parameters.Add("@telefoneCliente", MySqlDbType.VarChar).Value = cm.telefoneCliente;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelCliente> selecionaCliente()
        {
            List<modelCliente> animalList = new List<modelCliente>();

            MySqlCommand cmd = new MySqlCommand("select * from tbCliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                animalList.Add(
                    new modelCliente
                    {
                        idCliente = Convert.ToInt32(dr["idCliente"]),
                        nomeCliente = Convert.ToString(dr["nomeCliente"]),
                        sobrenomeCliente = Convert.ToString(dr["sobrenomeCliente"]),
                        emailCliente = Convert.ToString(dr["emailCliente"]),
                        telefoneCliente = Convert.ToString(dr["telefoneCliente"])
                    });
            }
            return animalList;
        }
        public void DeleteCliente(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbCliente where idCliente=@idCliente", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@idCliente", cod);
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }


    }
}