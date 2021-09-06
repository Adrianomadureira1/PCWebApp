using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCWebApp.Repository.Entity;
using PCWebApp.Services.Exceptions;
using PCWebApp.Services.Interface;

namespace PCWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PCController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorService _colaboradorService;

        public PCController(IMapper mapper, IColaboradorService colaboradorService)
        {
            _mapper = mapper;
            _colaboradorService = colaboradorService;
        }

        /// <summary>
        /// Obter todos os colaboradores.
        /// </summary>
        /// <response code="200">A lista de colaboradores foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro interno ao obter a lista de colaboradores.</response>
        /// <returns></returns>
        
        [HttpGet("colaborador")]
        [ProducesResponseType(typeof(List<ColaboradorDTO>), 200)]
        public IActionResult LerTodos(){
            try{
                return Ok(_colaboradorService.Ler());
            }
            catch(Exception){
                return StatusCode(500, "Ocorreu um erro interno ao obter a lista de colaboradores.");
            }
        }

        /// <summary>
        /// Obter colaborador com ID especificado.
        /// </summary>
        /// <param name="ID">ID do colaborador.</param>
        /// <response code="200">Os dados do colaborador especificado foram obtidos com sucesso.</response>
        /// <response code="404">Não foi possível obter os dados do colaborador com ID especificado.</response>
        /// <response code="500">Ocorreu um erro interno ao obter os dados do colaborador especificado.</response>
        /// <returns></returns>
        
        [HttpGet("colaborador/{ID}")]
        [ProducesResponseType(typeof(ColaboradorDTO), 200)]
        public IActionResult LerPorId(Guid ID){
            try{
                var result = Ok(_colaboradorService.Ler(ID));

                return Ok(result);
            }
            catch (ResourceNotFoundException){
                return NotFound("Não foi possível obter os dados do colaborador com ID especificado.");
            }
            catch (Exception){
                return StatusCode(500, "Ocorreu um erro interno ao obter os dados do colaborador especificado.");
            }
        }

        /// <summary>
        /// Cadastrar colaborador.
        /// </summary>
        /// <param name="colaboradorDTO">Modelo do colaborador.</param>
        /// <response code="200">Os dados do colaborador especificado foram obtidos com sucesso.</response>
        /// <response code="400">Ocorreu um erro de validação ao realizar o cadastro do colaborador.</response>
        /// <response code="500">Ocorreu um erro interno ao realizar o cadastro do colaborador.</response>
        /// <returns></returns>
        
        [HttpPost("colaborador")]
        [ProducesResponseType(typeof(ColaboradorDTO), 200)]
        public IActionResult CadastrarColaborador([FromBody] ColaboradorDTO colaboradorDTO){
            try{
                return Ok(_colaboradorService.Criar(colaboradorDTO));
            }
            catch (InvalidDataException e){
                return BadRequest("Ocorreu um erro de validação ao realizar o cadastro do colaborador: \n" + e.Message);
            }
            catch (Exception e){
                return StatusCode(500, "Ocorreu um erro interno ao realizar o cadastro do colaborador: \n" + e.Message);
            }
        }

        /// <summary>
        /// Modificar colaborador com ID especificado.
        /// </summary>
        /// <param name="colaboradorDTO">Modelo do colaborador.</param>
        /// <response code="200">Os dados do colaborador foram modificados com sucesso.</response>
        /// <response code="400">O modelo do colaborador enviado é inválido.</response>
        /// <response code="404">Não foi possível obter os dados do colaborador com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao modificar o colaborador especificado.</response>
        /// <returns></returns>
         
        [HttpPut("colaborador")]
        [ProducesResponseType(typeof(ColaboradorDTO), 200)]
        public IActionResult Atualizar([FromBody] ColaboradorDTO colaboradorDTO){
            try{
                return Ok(_colaboradorService.Modificar(colaboradorDTO));
            }
            catch (InvalidDataException e){
                return BadRequest("Ocorreu um erro de validação ao realizar a modificação dos dados do colaborador: \n" + e.Message);
            }
            catch (ResourceNotFoundException e){
                return NotFound("Não foi possível obter os dados do colaborador com ID especificado: \n" + e.Message);
            }
            catch (Exception e){
                return StatusCode(500, "Ocorreu um erro interno ao realizar o cadastro do colaborador: \n" + e.Message);
            }

        }

        /// <summary>
        /// Deletar colaborador com ID especificado.
        /// </summary>
        /// <param name="ID">ID do colaborador.</param>
        /// <response code="200">O colaborador foi deletado com sucesso.</response>
        /// <response code="404">Não foi possível obter os dados do colaborador com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter os dados do colaborador especificado.</response>
        /// <returns></returns>
        
        [HttpDelete("colaborador/{ID}")]
        public IActionResult Deletar(Guid ID){
            try{
                _colaboradorService.Deletar(ID);
                return Ok($"ID: {ID}");
            }
            catch (ResourceNotFoundException e){
                return NotFound("Não foi possível obter os dados do colaborador com ID especificado: \n" + e.Message);
            }
            catch (Exception e){
                return StatusCode(500, "Ocorreu um erro interno ao deletar os dados do colaborador: \n" + e.Message);
            }
        }
    }
}