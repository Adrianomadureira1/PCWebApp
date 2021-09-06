using FluentValidation;
using PCWebApp.Repository.Entity;

namespace PCWebApp.Repository.Validators
{
    public class ColaboradorValidator : AbstractValidator<Colaborador>
    {
        public ColaboradorValidator(){
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo 'Nome' não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Nome' não pode ser nulo.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O campo 'Email' não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Email' não pode ser nulo.")

                .EmailAddress()
                .WithMessage("O campo 'Email' não contém um endereço válido.");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("O campo 'Senha' não pode ser vazio.")
            
                .NotNull()
                .WithMessage("O campo 'Senha' não pode ser nulo.")
                
                .MinimumLength(5)
                .WithMessage("O campo 'Senha' deve ter no mínimo 5 caracteres.")
                
                .MaximumLength(20)
                .WithMessage("O campo 'Senha' deve ter no máximo 20 caracteres.");

            RuleFor(x => x.Idade)
                .NotEmpty()
                .WithMessage("O campo 'Idade' não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Idade' não pode ser nulo.");

            RuleFor(x => x.PRS)
                .NotNull()
                .WithMessage("O campo 'PRS' (Páginas de Redes Sociais) não pode ser nulo.");

            RuleFor(x => x.Descricao)
                .NotNull()
                .WithMessage("O campo 'Descricao' não pode ser nulo.");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("O campo 'Status' não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Status' não pode ser nulo.")
                
                .Must(x => x.Equals("Ativo") || x.Equals("Inativo")).WithMessage("O campo 'Status' deve possuir os valores 'Ativo' ou 'Inativo'.");

            RuleFor(x => x.Departamentos)
                .NotEmpty()
                .WithMessage("O campo 'Departamentos' não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Departamentos' não pode ser nulo.");

            RuleFor(x => x.Grupos)
                .NotEmpty()
                .WithMessage("O campo 'Grupos' não pode ser vazio.")

                .NotNull()
                .WithMessage("O campo 'Grupos' não pode ser nulo.");
        }
    }
}