using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PCWebApp.Repository.Entity;
using PCWebApp.Repository.Interfaces;
using PCWebApp.Services.Exceptions;
using PCWebApp.Services.Interface;

namespace PCWebApp.Services
{
    public class ColaboradorService: IColaboradorService
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepository<Colaborador> _colaboradorRepository;

        public ColaboradorService(IMapper mapper, IColaboradorRepository<Colaborador> colaboradorRepository)
        {
            _mapper = mapper;
            _colaboradorRepository = colaboradorRepository;
        }

        public List<ColaboradorDTO> Ler(){
            var colaboradores = _colaboradorRepository.Ler();

            return _mapper.Map<List<ColaboradorDTO>>(colaboradores);
        }

        public ColaboradorDTO Ler(Guid ID){
            var colaborador = _colaboradorRepository.Ler(ID);

            if (colaborador == null) {
                throw new ResourceNotFoundException("Não foi possível obter os dados do colaborador com ID especificado.");
            }

            return _mapper.Map<ColaboradorDTO>(colaborador);
        }

        public ColaboradorDTO Criar(ColaboradorDTO colaboradorDTO){
            var colaboradorExiste = _colaboradorRepository.LerPorEmail(colaboradorDTO.Email);
            
            if (colaboradorExiste != null) {
                throw new Exception("Já existe um colaborador cadastrado com o email informado.");
            }

            var colaborador = _mapper.Map<Colaborador>(colaboradorDTO);

            colaborador.Validate();

            colaborador.Departamentos.ToList().ForEach(c => c.Validate());
            colaborador.Grupos.ToList().ForEach(g => g.Validate());

            var colaboradorCriado = _colaboradorRepository.Criar(colaborador);
            
            return _mapper.Map<ColaboradorDTO>(colaboradorCriado);
        }

        public ColaboradorDTO Modificar(ColaboradorDTO colaboradorDTO){
            var colaboradorExiste = _colaboradorRepository.Ler(colaboradorDTO.ID);

            if (colaboradorExiste == null) {
                throw new ResourceNotFoundException("Colaborador não identificado no Banco de Dados.");
            }

            var colaborador = _mapper.Map<Colaborador>(colaboradorDTO);

            colaborador.Validate();

            var colaboradorModificado = _colaboradorRepository.Modificar(colaborador);

            return _mapper.Map<ColaboradorDTO>(colaboradorModificado);
        }

        public void Deletar(Guid ID){
            var colaboradorDTO = Ler(ID);

            if (colaboradorDTO == null) {
                throw new ResourceNotFoundException("Colaborador não identificado.");
            }

            var colaborador = _mapper.Map<Colaborador>(colaboradorDTO);

            _colaboradorRepository.Deletar(colaborador);
        }
    }
}