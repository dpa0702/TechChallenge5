﻿using GestaoInvestimentosCore.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestaoInvestimentosCore.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

        public Usuario()
        {
            Portfolios = new HashSet<Portfolio>();
        }

        public Usuario(int id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;

            ValidateEntity();
        }

        public Usuario(CreateUsuarioDTO createUsuarioDTO)
        {
            Id = createUsuarioDTO.Id;
            Nome = createUsuarioDTO.Nome;
            Email = createUsuarioDTO.Email;
            Senha = createUsuarioDTO.Senha;

            ValidateEntity();
        }

        public Usuario(UpdateUsuarioDTO updateUsuarioDTO)
        {
            Id = updateUsuarioDTO.Id;
            Nome = updateUsuarioDTO.Nome;
            Email = updateUsuarioDTO.Email;
            Senha = updateUsuarioDTO.Senha;

            ValidateEntity();
        }

        public void ValidateEntity()
        {
            AssertionValidations.AssertArgumentNullOrEmpty(Nome, "O nome não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Email, "O email não pode ser nulo nem vazio!");
            AssertionValidations.AssertArgumentNullOrEmpty(Senha, "A senha não pode ser nulo nem vazio!");

            AssertionValidations.AssertArgumentLenght(Nome, 100, "O nome deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Email, 100, "O email deve ter no máximo 100 caracteres!");
            AssertionValidations.AssertArgumentLenght(Senha, 50, "A senha deve ter no máximo 50 caracteres!");
        }
    }
}
