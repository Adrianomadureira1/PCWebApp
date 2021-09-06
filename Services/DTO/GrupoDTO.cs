using System;
using System.ComponentModel.DataAnnotations;

namespace PCWebApp.Repository.Entity
{
    public class GrupoDTO
    {
        public GrupoDTO()
        {
        }

        public GrupoDTO(Guid id, string nome)
        {
            ID = id;
            Nome = nome;
        }

        public Guid ID { get; set; }
        
        [RegularExpression("CLT|PJ|Freelancer|Parceiros|Outros", 
        ErrorMessage = "O campo 'Departamentos' deve possuir em 'Nome' um dos seguintes valores: 'CLT', 'PJ', 'Freelancer', 'Parceiros', 'Outros'.")]
        public string Nome { get; set; }
    }
}