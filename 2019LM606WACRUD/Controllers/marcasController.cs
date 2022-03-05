using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2019LM606WACRUD.Models;

namespace _2019LM606WACRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class marcasController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public marcasController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }


        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get()
        {

            IEnumerable<marcas> marcasList = (from m in _contexto._marca
                                              select m);


            if (marcasList.Count() > 0)
            {
                return Ok(marcasList);

            }

            return NotFound();
        }



        [HttpGet]
        [Route("api/marcas/{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            marcas marca = (from m in _contexto._marca
                            where m.id_marcas == idUsuario
                            select m).FirstOrDefault();

            if (marca != null)
            {
                return Ok(marca);

            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/marcas")]
        public IActionResult guardarEquipo([FromBody] marcas nuevaMarca)
        {
            try
            {
                _contexto._marca.Add(nuevaMarca);
                _contexto.SaveChanges();
                return Ok(nuevaMarca);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/marcas")]
        public IActionResult updateEquipment([FromBody] marcas marcaToUpdate)
        {
            //obtener el registro original

            marcas marca = (from m in _contexto._marca
                            where m.id_marcas == marcaToUpdate.id_marcas
                            select m).FirstOrDefault();

            if (marca is null)
            {
                return NotFound();
            }

            marca.nombre_marca = marcaToUpdate.nombre_marca;


            _contexto.Entry(marca).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(marca);
        }
    }
}
