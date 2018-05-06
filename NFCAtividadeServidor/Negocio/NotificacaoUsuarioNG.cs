﻿using Persistencia.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NotificacaoUsuarioNG
    {
        public static Boolean addNotificacao(NotificacaoUsuario notificacao)
        {
            return Persistencia.NotificacaoUsuarioDD.addNotificacao(notificacao);
        }

        public static List<NotificacaoUsuario> getNotificacoesByUsuario(int idUsuario)
        {
            List<NotificacaoUsuario> listaNotificacoes = new List<NotificacaoUsuario>();

            List<NotificacaoUsuarioAddAtividade> listNotAddAtividade = NotificacaoUsuarioAddAtividadeNG.getNotificacoesAddAtividadeByUsuario(idUsuario);
            List<NotificacaoUsuarioProblemaTarefa> listNotProblemaTarefa = NotificacaoUsuarioProblemaTarefaNG.getNotificacoesProblemaTarefaByUsuario(idUsuario);

            var allNotificacoes = listaNotificacoes.Concat(listNotAddAtividade)
                                    .Concat(listNotProblemaTarefa)
                                    .ToList();
            return allNotificacoes;
            //return Persistencia.NotificacaoUsuarioDD.getNotificacoesByUsuario(idUsuario);
        }

        public static bool updateNotificacao(NotificacaoUsuario notificacao)
        {
            return Persistencia.NotificacaoUsuarioDD.updateNotificacao(notificacao);
        }

        public static int getCountNotificacoesParaVisualizarUsuario(int idUsuario)
        {
            return Persistencia.NotificacaoUsuarioDD.getCountNotificacoesParaVisualizarUsuario(idUsuario);
        }
    }
}
