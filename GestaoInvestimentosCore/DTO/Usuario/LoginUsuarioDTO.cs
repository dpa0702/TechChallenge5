﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInvestimentosCore.DTO.Usuario
{
    public class LoginUsuarioDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
