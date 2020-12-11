using BelaRosa_MVC_AspNetCore3_4.Models.Repositories.Interfaces;
using BelaRosa_MVC_AspNetCore3_4.Data;
using BelaRosa_MVC_AspNetCore3_4.Models.Entities;
using BelaRosa_MVC_AspNetCore3_4.Models.Constant;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BelaRosa_MVC_AspNetCore3_4.Models.Repositories
{
    public class ColaboradorRepository : IColaborador
    {
        private IConfiguration _configuration;
        private BelaRosaContext _context;
        public ColaboradorRepository(BelaRosaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void Atualizar(Colaborador colaborador)
        {
            _context.Update(colaborador);
            _context.Entry(colaborador).Property(a => a.Senha).IsModified = false; //atualiza todos os campos menos a senha
            _context.SaveChanges();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            _context.Update(colaborador);

            _context.Entry(colaborador).Property(a => a.Nome).IsModified = false;
            _context.Entry(colaborador).Property(a => a.Email).IsModified = false;
            _context.Entry(colaborador).Property(a => a.Tipo).IsModified = false;

            _context.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(int Id)
        {
            Colaborador colaborador = ObterColaborador(Id);
            _context.Remove(colaborador);
            _context.SaveChanges();
        }

        public Colaborador Login(string Email, string Senha)
        {
            
             Colaborador colaborador = null;
             colaborador = _context.Colaborador.Where(m=>m.Email == Email && m.Senha == Senha)
             .FirstOrDefault();
             return colaborador;
        }

        public Colaborador ObterColaborador(int Id)
        {
           return _context.Colaborador.Find(Id);
        }

        public List<Colaborador> ObterColaboradorPorEmail(string email)
        {
            return _context.Colaborador.Where(a=>a.Email == email).ToList(); 
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            return _context.Colaborador.Where(a=>a.Tipo !=ColaboradorTipoConstants.Gerente).ToList<Colaborador>();
        }
    }
}