using FluentValidation;
using PCWebApp.Repository.Entity;

namespace PCWebApp.Repository.Validators
{
    public class GrupoValidator: AbstractValidator<Grupo>
    {
        public GrupoValidator(){
            RuleFor(x => x.Nome)
                    .NotEmpty()
                    .WithMessage("O campo 'Nome' do Departamento não pode ser vazio.")

                    .NotNull()
                    .WithMessage("O campo 'Nome' do Departamento não pode ser nulo.")
                    
                    .Must(x => x.Equals("CLT") || x.Equals("PJ") || x.Equals("Freelancer") || x.Equals("Parceiros") || x.Equals("Outros"))
                    .WithMessage("O campo 'Departamentos' deve possuir em 'Nome' os valores: 'CLT', 'PJ', 'Freelancer', 'Parceiros', 'Outros'");
        }
    }
}