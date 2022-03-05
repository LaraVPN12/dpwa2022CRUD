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
    public class tipoEquipoController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public tipoEquipoController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }


        [HttpGet]
        [Route("api/tipos")]
        public IActionResult Get()
        {

            IEnumerable<tipoEquipo> tiposList = (from t in _contexto._tipo
                                                 select t);


            if (tiposList.Count() > 0)
            {
                return Ok(tiposList);

            }

            return NotFound();
        }



        [HttpGet]
        [Route("api/tipos/{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            tipoEquipo tipo = (from t in _contexto._tipo
                               where t.id_tipo_equipo == idUsuario
                               select t).FirstOrDefault();

            if (tipo != null)
            {
                return Ok(tipo);

            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/tipos")]
        public IActionResult guardarEquipo([FromBody] tipoEquipo nuevoTipo)
        {
            try
            {
                _contexto._tipo.Add(nuevoTipo);
                _contexto.SaveChanges();
                return Ok(nuevoTipo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/tipos")]
        public IActionResult updateEquipment([FromBody] tipoEquipo tipoToUpdate)
        {
            //obtener el registro original

            tipoEquipo tipo = (from t in _contexto._tipo
                               where t.id_tipo_equipo == tipoToUpdate.id_tipo_equipo
                               select t).FirstOrDefault();

            if (tipo is null)
            {
                return NotFound();
            }

            tipo.descripcion = tipoToUpdate.descripcion;
            tipo.estado = tipoToUpdate.estado;


            _contexto.Entry(tipo).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(tipo);

        }
    }
}
