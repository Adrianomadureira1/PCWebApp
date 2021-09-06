using FluentValidation;
using PCWebApp.Repository.Entity;

namespace PCWebApp.Repository.Validators
{
    public class DepartamentoValidator: AbstractValidator<Departamento>
    {
        public DepartamentoValidator(){
        RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo 'Nome' do Departamento não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Nome' do Departamento não pode ser nulo.")
                
                .Must(x => x.Equals("FINANCEIRO") || x.Equals("ADMINISTRAÇÃO") || x.Equals("DIREÇÃO") || x.Equals("OPERACIONAL") || x.Equals("INFRAESTRUTURA") || x.Equals("DESENVOLVIMENTO") || x.Equals("COMERCIAL"))
                .WithMessage("O campo 'Departamentos' deve possuir em 'Nome' os valores: 'FINANCEIRO', 'ADMINISTRAÇÃO', 'DIREÇÃO', 'OPERACIONAL', 'INFRAESTRUTURA', 'DESENVOLVIMENTO' e 'COMERCIAL'.");
        }
    }
}