using System.Collections.Generic;
using PCWebApp.Repository.Entity;
using Swashbuckle.AspNetCore.Filters;

namespace PCWebApp.Controllers.SwaggerExamples.Requests
{
    public class ColaboradorDTOExample : IExamplesProvider<ColaboradorDTO>
    {
        public ColaboradorDTO GetExamples()
        {
            return new ColaboradorDTO {
                Nome = "João",
                Email = "joao@gmail.com",
                Idade = 22,
                Senha = "12345",
                Status = "Ativo",
                Descricao = "Motivado a cada novo desafio.",
                PRS = new List<string>(){"http://www.github.com/joao"},
                Departamentos = new List<DepartamentoDTO>() {
                    new DepartamentoDTO() {Nome = "ADMINISTRAÇÃO"},
                    new DepartamentoDTO() {Nome = "FINANCEIRO"}
                },
                Grupos = new List<GrupoDTO>() {
                    new GrupoDTO() {Nome = "CLT"},
                    new GrupoDTO() {Nome = "Outros"}
                }
            };
        }
    }
}