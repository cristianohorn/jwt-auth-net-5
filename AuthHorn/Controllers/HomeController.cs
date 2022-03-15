﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthHorn.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";
     
        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Authenticated() => string.Format("Autenticado - {0} ", User.Identity.Name);

        [HttpGet]
        [Route("funcionario")]
        [Authorize(Roles="employee,manager")]
        public string Employee() => "Funcionario";

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles="manager")]
        public string Manager() => "Gerente";
        
    }
}
