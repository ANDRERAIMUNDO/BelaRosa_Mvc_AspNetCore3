using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BelaRosa_MVC_AspNetCore3_4.Migrations;
using BelaRosa_MVC_AspNetCore3_4.Models.Libres;
using BelaRosa_MVC_AspNetCore3_4.Models.Libres.Login;
using BelaRosa_MVC_AspNetCore3_4.Models.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
namespace BelaRosa_MVC_AspNetCore3_4.Controllers
{
    public class ColaboradorController
    {
         private IColaborador _colaborador;
        private LoginColaborador _loginColaborador;
        public ColaboradorController(IColaborador colaborador, LoginColaborador loginColaborador)
        {
            _colaborador = colaborador;
            _loginColaborador = loginColaborador;
        }
    }
}