using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace API_ANIMAIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        [HttpGet()]
        public List<Animais> Get()
        {
            try
            {
                ComandosSql comandosSql = new ComandosSql();
                List<Animais> animais = comandosSql.Seleciona();
                return animais;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Animais>();
                throw;
            }
        }
        [HttpPost]
        public string Post(string nome, string classe, int pes, int voa)
        {
            try
            {
                ComandosSql comandosSql = new ComandosSql();
                string aviso = comandosSql.Insere(nome, classe, pes, voa);
                return aviso;
            }
            catch (Exception e)
            {
                return e.ToString();
                throw;
            }
        }
       
        public string Put(int id_a, string nome, string classe, int pes, int voa)
        {
            try
            {
                ComandosSql comandosSql = new ComandosSql();
                string aviso = comandosSql.Altera(id_a, nome, classe, pes, voa);
                return aviso;
            }
            catch (Exception e)
            {
                return e.ToString();
                throw;
            }
        }
        [HttpDelete]
        public string Delete(int id_a)
        {

            try
            {
                ComandosSql comandosSql = new ComandosSql();
                string aviso = comandosSql.Apaga(id_a);
                return aviso;
            }
            catch (Exception e)
            {
                return e.ToString();
                throw;
            }
        }
    }
}
