﻿using LibraryDB;
using Persistencia.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioDD
    {
        public static Usuario getUsuario(string login, string senha)
        {
            IDbConnection conexao = null;
            IDataReader dReader = null;

            try
            {

                //string sql = "select * from Usuario where login = " + login + " AND " + "senha = " + senha;
                string sql = "select * from Usuario";

                conexao = DataBase.getConection();
                IDbCommand command = DataBase.getCommand(sql, conexao);

                IDbDataParameter parametro = command.CreateParameter();
                DataBase.getParametroCampo(ref parametro, "@nome", login.Trim(), tipoDadoBD.VarChar);
                command.Parameters.Add(parametro);

                parametro = command.CreateParameter();
                DataBase.getParametroCampo(ref parametro, "@senha", senha, tipoDadoBD.VarChar);
                command.Parameters.Add(parametro);

                conexao.Open();
                dReader = command.ExecuteReader();

                if (dReader != null)
                {
                    dReader.Read();
                    Usuario usuario = new Usuario();
                    if (dReader["id_usuario"] != DBNull.Value)
                    {                        
                        usuario.Id = Int32.Parse(dReader["id_usuario"].ToString());
                    }
                    conexao.Close();
                    dReader.Close();
                    return usuario;
                }
                else
                {
                    throw new Exception("[UsuarioDD.getUsuario()]: Não foi possível localizar o usuário.");
                }
            }
            catch (Exception exp)
            {
                throw new Exception("[UsuarioDD.getUsuario()]: " + exp.Message);
            }
            finally
            {
                if (dReader != null) dReader.Close();
                if (conexao != null) conexao.Close();
            }
        }
    }
}