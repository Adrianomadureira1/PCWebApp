using System;
using System.ComponentModel.DataAnnotations;

namespace PCWebApp.Repository.Entity
{
    public class DepartamentoDTO
    {
        public DepartamentoDTO()
        {
        }

        public DepartamentoDTO(Guid id, string nome)
        {
            ID = id;
            Nome = nome;
        }
        public Guid ID { get; set; }

        [RegularExpression("FINANCEIRO|ADMINISTRAÇÃO|DIREÇÃO|OPERACIONAL|INFRAESTRUTURA|DESENVOLVIMENTO|COMERCIAL", 
        ErrorMessage = "O campo 'Departamentos' deve possuir em 'Nome' um dos seguintes valores: 'FINANCEIRO', 'ADMINISTRAÇÃO', 'DIREÇÃO', 'OPERACIONAL', 'INFRAESTRUTURA', 'DESENVOLVIMENTO' e 'COMERCIAL'.")]
        public string Nome { get; set; }
    }
}