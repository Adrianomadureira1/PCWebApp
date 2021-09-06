using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCWebApp.Repository.Entity
{
    public class ColaboradorDTO
    {
        public ColaboradorDTO()
        {
        }

        public ColaboradorDTO(Guid id, string nome, string email, int idade, string senha, string status, string descricao, ICollection<DepartamentoDTO> departamentos, ICollection<GrupoDTO> grupos, List<string> prs)
        {
            ID = id;
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

        public Guid ID { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode ser vazio.")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Email' não pode ser vazio.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Idade' não pode ser vazio.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' não pode ser vazio.")]
        [MinLength(5, ErrorMessage = "O campo 'Senha' deve conter no mínimo 5 caracteres.")]
        [MaxLength(20, ErrorMessage = "O campo 'Senha' deve conter no máximo 20 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo 'Status' não pode ser vazio.")]
        public string Status { get; set; }
        
        public string Descricao { get; set; }

        public List<string> PRS { get; set; }

        [Required(ErrorMessage = "O campo 'Departamentos' não pode ser vazio.")]
        public ICollection<DepartamentoDTO> Departamentos { get; set; }

        [Required(ErrorMessage = "O campo 'Grupos' não pode ser vazio.")]
        public ICollection<GrupoDTO> Grupos { get; set; }
    }
}