using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PCWebApp.Repository.Entity;
using PCWebApp.Repository.Interfaces;

namespace PCWebApp.Repository
{
    public class ColaboradorRepository<TEntity> : IColaboradorRepository<Colaborador>
        where TEntity : Colaborador
    {
        private readonly PCDbContext _pcDbContext;
        
        public ColaboradorRepository(PCDbContext pcDbContext)
        {
            _pcDbContext = pcDbContext;
        }

        public virtual List<Colaborador> Ler(){
            return _pcDbContext.Set<Colaborador>()
                    .AsNoTracking()
                    .Include(_ => _.Departamentos)
                    .Include(_ => _.Grupos)
                    .ToList();
        }

        public virtual Colaborador Ler(Guid ID){
            return _pcDbContext.Set<Colaborador>()
                    .Where(x => x.ID == ID)
                    .Include(_ => _.Departamentos)
                    .Include(_ => _.Grupos)
                    .ToList()
                    .FirstOrDefault();
        }

        public virtual Colaborador LerPorEmail(string email){
            return _pcDbContext.Colaboradores.Where(x => x.Email == email).Select(x => x).SingleOrDefault();
        }

        public virtual Colaborador Criar(Colaborador colaborador){
            colaborador.Departamentos = LerDepartamentos(colaborador);
            colaborador.Grupos = LerGrupos(colaborador);

            _pcDbContext.Add(colaborador);
            _pcDbContext.SaveChanges();

            return colaborador;
        }

        public virtual Colaborador Modificar(Colaborador colaborador){
            var colaboradorExistente = Ler(colaborador.ID);

            colaboradorExistente.Departamentos = LerDepartamentos(colaborador);
            colaboradorExistente.Grupos = LerGrupos(colaborador);

            _pcDbContext.Entry(colaboradorExistente).State = EntityState.Modified;
            _pcDbContext.SaveChanges();

            return colaboradorExistente;
        }
        
        public void Deletar(Colaborador colaborador){
            _pcDbContext.Remove(colaborador);
            _pcDbContext.SaveChanges();
        }

        public List<Departamento> LerDepartamentos(Colaborador colaborador){
            var departamentos = new List<Departamento>();

            colaborador.Departamentos.ToList().ForEach(d => {
                departamentos.Add(_pcDbContext.Departamentos.Where(x => x.Nome == d.Nome).Select(x => x).First());
            });

            return departamentos;
        }

        public List<Grupo> LerGrupos(Colaborador colaborador){
            var grupos = new List<Grupo>();

            colaborador.Grupos.ToList().ForEach(g => {
                grupos.Add(_pcDbContext.Grupos.Where(x => x.Nome == g.Nome).Select(x => x).First());
            });

            return grupos;
        }
    }
}