using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository; //Professor nomeou a variável como repository
        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Ler());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)     
        {
            try
            {
                _projetoRepository.Cadastrar(projeto);
                return Ok(projeto);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(int id, Projeto projeto)
        {
            try
            {
                _projetoRepository.Atualizar(id, projeto);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("(id)")] 
        public IActionResult GetById(int id)
        {
            try
            {
                Projeto projeto = _projetoRepository.BuscarPorId(id);

                if (projeto == null)
                {
                    return NotFound();
                }
                return Ok(projeto);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("(título)")]
        public IActionResult GetPorTitulo(string titulo)
        {
            try
            {
                Projeto projeto = _projetoRepository.BuscarPorTitulo(titulo);
                if (projeto == null)
                {
                    return NotFound();
                }
                return Ok(projeto);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
