using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PCWebApp.Repository.Validators;
using PCWebApp.Services.Exceptions;

namespace PCWebApp.Repository.Entity
{
    public class Colaborador
    {
        public Colaborador()
        {
        }

        public Colaborador(Guid iD, string nome, string email, int idade, string senha, string status, string descricao, ICollection<Departamento> departamentos, ICollection<Grupo> grupos, string prs)
        {
            ID = iD;
            Nome = nome;
            Email = email;
            Idade = idade;
            Senha = senha;
            Status = status;
            Descricao = descricao;
            Departamentos = departamentos;
            Grupos = grupos;
            PRS = prs;
        }

        [Key]
        public Guid ID { get; set; }
        
        public string Nome { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }

        public string Status { get; set; }

        public string Descricao { get; set; }

        public string PRS { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }

        public bool Validate(){
            var validator = new ColaboradorValidator();

            var validation = validator.Validate(this);

            var _errors = new List<string>();

            validation.Errors.ForEach(error => _errors.Add(error.ErrorMessage));

            if (_errors.Count > 0) {
                throw new InvalidDataException(string.Join("\n", _errors));
            }
            
            return true;
        }
    }
}