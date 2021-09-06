using System;
using System.Collections.Generic;

namespace PCWebApp.Repository.Interfaces
{
    public interface IColaboradorRepository<Colaborador>
    {
        List<Colaborador> Ler();
        Colaborador Ler(Guid ID);
        Colaborador LerPorEmail(string email);
        Colaborador Criar(Colaborador colaborador);
        Colaborador Modificar(Colaborador colaborador);
        void Deletar(Colaborador colaborador);
    }
}