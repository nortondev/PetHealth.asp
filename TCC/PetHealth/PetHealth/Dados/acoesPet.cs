using MySql.Data.MySqlClient;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PetHealth.Dados
{
    public class acoesPet
    {
        Conexao con = new Conexao();

        public void inserirPet(modelPet cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPet (nomePet, idAnimal, idSexo, racaPet, idadePet, pesoPet, fotoPet, idPlano, idCliente)" +
                " values(@nomePet, @idAnimal, @idSexo, @racaPet, @idadePet, @pesoPet, @fotoPet, @idPlano, @idCliente)", con.MyConectarBD());


            cmd.Parameters.Add("@nomePet", MySqlDbType.VarChar).Value = cm.nomePet;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;
            cmd.Parameters.Add("@idSexo", MySqlDbType.Int32).Value = cm.idSexo;
            cmd.Parameters.Add("@racaPet", MySqlDbType.VarChar).Value = cm.racaPet;
            cmd.Parameters.Add("@idadePet", MySqlDbType.Int32).Value = cm.idadePet;
            cmd.Parameters.Add("@pesoPet", MySqlDbType.Int32).Value = cm.pesoPet;
            cmd.Parameters.Add("@fotoPet", MySqlDbType.VarChar).Value = cm.fotoPet;
            cmd.Parameters.Add("@idPlano", MySqlDbType.Int32).Value = cm.idPlano;
            cmd.Parameters.Add("@idCLiente", MySqlDbType.VarChar).Value = cm.idCliente;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelPet> selecionaPet()
        {
            List<modelPet> petList = new List<modelPet>();

            MySqlCommand cmd = new MySqlCommand("select * from vwPet", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                petList.Add(
                    new modelPet
                    {
                        idPet = Convert.ToInt32(dr["idPet"]),
                        nomePet = Convert.ToString(dr["nomePet"]),
                        Animal = Convert.ToString(dr["Animal"]),
                        Sexo = Convert.ToString(dr["Sexo"]),
                        racaPet = Convert.ToString(dr["racaPet"]),
                        idadePet = Convert.ToInt32(dr["idadePet"]),
                        pesoPet = Convert.ToInt32(dr["pesoPet"]),
                        fotoPet = Convert.ToString(dr["fotoPet"]),
                        nomePlano = Convert.ToString(dr["nomePlano"]),
                        nomeCliente = Convert.ToString(dr["nomeCliente"])
                    });
            }
            return petList;
        }

        public void atualizarPet(modelPet pt)
        {
            MySqlCommand cmd = new MySqlCommand("update tbPet set nomePet=@nomePet, idSexo=@idSexo," +
                " racaPet=@racaPet, idadePet=@idadePet, pesoPet=@pesoPet, fotoPet=@fotoPet, idPlano=@idPlano where idPet=@idPet ", con.MyConectarBD());

            cmd.Parameters.Add("@idPet", MySqlDbType.VarChar).Value = pt.idPet;
            cmd.Parameters.Add("@nomePet", MySqlDbType.VarChar).Value = pt.nomePet;
            cmd.Parameters.Add("@idSexo", MySqlDbType.VarChar).Value = pt.idSexo;
            cmd.Parameters.Add("@racaPet", MySqlDbType.VarChar).Value = pt.racaPet;
            cmd.Parameters.Add("@idadePet", MySqlDbType.VarChar).Value = pt.idadePet;
            cmd.Parameters.Add("@pesoPet", MySqlDbType.VarChar).Value = pt.pesoPet;
            cmd.Parameters.Add("@fotoPet", MySqlDbType.VarChar).Value = pt.fotoPet;
            cmd.Parameters.Add("@idPlano", MySqlDbType.VarChar).Value = pt.idPlano;


            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

        }

        public void DeletePet(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbPet where idPet=@idPet", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@idPet", cod);
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}