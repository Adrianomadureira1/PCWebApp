using System;
using System.Collections.Generic;
using PCWebApp.Repository.Entity;

namespace PCWebApp.Services.Interface
{
    public interface IColaboradorService
    {
        List<ColaboradorDTO> Ler();
        ColaboradorDTO Ler(Guid ID);
        ColaboradorDTO Criar(ColaboradorDTO colaboradorDTO);
        ColaboradorDTO Modificar(ColaboradorDTO colaboradorDTO);
        void Deletar(Guid ID);
    }
}