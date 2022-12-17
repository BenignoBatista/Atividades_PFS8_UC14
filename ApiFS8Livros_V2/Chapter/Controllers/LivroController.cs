using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Chapter.Controllers
{
    [Produces("application/json")]//formato de reposta da api : json
    [Route("api/[controller]")]//rota para acesso do controller : api/livro
    [ApiController]//identificação que é uma classe controladora
    public class LivroController : ControllerBase//herança da classe ControllerBase
    {
        private readonly LivroRepository _livroRepository;//variável privada criada para armazenar os dados do repositório

        public LivroController(LivroRepository livroRepository)//injeção de dependência: o controller depende do repository
        {
            _livroRepository = livroRepository;//armazenamento das informações do repositório dentro da variável privada
        }

        [HttpGet]//verbo Get: de obter
        //IActionResult : https://learn.microsoft.com/pt-br/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0
        public IActionResult Listar()//nome do controller para listar os livros 
        {
            try//caso dê certo
            {
                return Ok(_livroRepository.Ler());//retorna um status code 200 e os itens da lista
            }
            catch (Exception e)//caso dê errado
            {
                throw new Exception(e.Message);//retorna uma mensagem de erro
            }
        }


        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(int id, Livro livro)
        {
            try
            {
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Livro livro = _livroRepository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

       /* [HttpGet("{titulo}")]
        public IActionResult ListarPorTitulo(string titulo)
        {
            try
            {
                Livro livro = _livroRepository.BuscarPorTitulo(titulo);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }*/
    }
}
