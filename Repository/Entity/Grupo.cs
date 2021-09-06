using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json.Serialization;
using PCWebApp.Repository.Validators;

namespace PCWebApp.Repository.Entity
{
    public class Grupo
    {
        public Grupo()
        {
        }

        public Grupo(Guid iD, string nome)
        {
            ID = iD;
            Nome = nome;
        }

        [Key]
        public Guid ID { get; set; }

        public string Nome { get; set; }
        [JsonIgnore]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }

        public bool Validate(){
            var validator = new GrupoValidator();

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