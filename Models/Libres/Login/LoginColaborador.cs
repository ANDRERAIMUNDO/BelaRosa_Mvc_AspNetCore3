using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelaRosa_MVC_AspNetCore3_4.Models.Entities;
namespace BelaRosa_MVC_AspNetCore3_4.Models.Libres.Login
{
    public class LoginColaborador
    {
        private string Key = "LoginColaborador";
        private Sessao.Sessao _sessao;
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }
        public void Login(Colaborador colaborador)
        {
            //Serializar
            string colaboradorJSonString = JsonConvert.SerializeObject(colaborador);
            _sessao.Cadastrar(Key, colaboradorJSonString);
        }
        public Colaborador GetColaborador()
        {
            //Deserializar
            if (_sessao.Existe(Key))//sessao existe ?
            {
                string colaboradorJSonString = _sessao.Consulta(Key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSonString);
            }
            else
            {
                return null;
            }
        }
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}