using System;
using BelaRosa_MVC_AspNetCore3_4.Models.Entities;
using System.Collections.Generic;
namespace BelaRosa_MVC_AspNetCore3_4.Models.Repositories.Interfaces
{
    public interface IColaborador
    {
        Colaborador Login(string Email, string Senha);
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void AtualizarSenha(Colaborador colaborador);
        void Excluir(int Id);
        Colaborador ObterColaborador(int Id);
        List<Colaborador> ObterColaboradorPorEmail(string email);
        IEnumerable<Colaborador> ObterTodosColaboradores(int? pagina);
    }
}