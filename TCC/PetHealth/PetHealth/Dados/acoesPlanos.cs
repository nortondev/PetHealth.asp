using MySql.Data.MySqlClient;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PetHealth.Dados
{
    public class acoesPlanos
    {
        Conexao con = new Conexao();

        public void inserirPlanos(modelPlanos cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPlano values(default, @nomePlano, @descPlano, @valorPlano, @fotoPlano)", con.MyConectarBD());

            cmd.Parameters.Add("@nomePlano", MySqlDbType.VarChar).Value = cm.nomePlano;
            cmd.Parameters.Add("@descPlano", MySqlDbType.VarChar).Value = cm.descPlano;
            cmd.Parameters.Add("@valorPlano", MySqlDbType.VarChar).Value = cm.valorPlano;
            cmd.Parameters.Add("@fotoPlano", MySqlDbType.VarChar).Value = cm.fotoPlano;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelPlanos> selecionaPlano()
        {
            List<modelPlanos> planosList = new List<modelPlanos>();

            MySqlCommand cmd = new MySqlCommand("select * from tbPlano", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                planosList.Add(
                    new modelPlanos
                    {
                        idPlano = Convert.ToInt32(dr["idPlano"]),
                        nomePlano = Convert.ToString(dr["nomePlano"]),
                        descPlano = Convert.ToString(dr["descPlano"]),
                        valorPlano = Convert.ToString(dr["valorPlano"]),
                        fotoPlano = Convert.ToString(dr["fotoPlano"])
                    });
            }
            return planosList;
        }
        public void DeletePlano(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbPlano where idPet=@idPlano", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@idPlano", cod);
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}