using MySql.Data.MySqlClient;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PetHealth.Dados
{
    public class acoesAnimal
    {
        Conexao con = new Conexao();

        public void inserirAnimal(modelAnimal cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAnimal values(default, @Animal, @descAnimal, @fotoAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@Animal", MySqlDbType.VarChar).Value = cm.Animal;
            cmd.Parameters.Add("@descAnimal", MySqlDbType.VarChar).Value = cm.descAnimal;
            cmd.Parameters.Add("@fotoAnimal", MySqlDbType.VarChar).Value = cm.fotoAnimal;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelAnimal> selecionaAnimal()
        {
            List<modelAnimal> animalList = new List<modelAnimal>();

            MySqlCommand cmd = new MySqlCommand("select * from tbAnimal", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                animalList.Add(
                    new modelAnimal
                    {
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        Animal = Convert.ToString(dr["Animal"]),
                        descAnimal = Convert.ToString(dr["descAnimal"]),
                        fotoAnimal = Convert.ToString(dr["fotoAnimal"])
                    });
            }
            return animalList;
        }
    }
}