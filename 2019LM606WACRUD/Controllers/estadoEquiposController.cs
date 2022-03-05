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
    public class estadoEquiposController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public estadoEquiposController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }


        [HttpGet]
        [Route("api/estados")]
        public IActionResult Get()
        {

            IEnumerable<estadoEquipos> estadosList = (from eq in _contexto.estado_equipos select eq);


            if (estadosList.Count() > 0)
            {
                return Ok(estadosList);

            }

            return NotFound();
        }



        [HttpGet]
        [Route("api/estados/{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            estadoEquipos estado = (from e in _contexto.estado_equipos
                                     where e.id_estados_equipo == idUsuario
                                     select e).FirstOrDefault();

            if (estado != null)
            {
                return Ok(estado);

            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/estados")]
        public IActionResult guardarEquipo([FromBody] estadoEquipos nuevoEstado)
        {
            try
            {
                _contexto.estado_equipos.Add(nuevoEstado);
                _contexto.SaveChanges();
                return Ok(nuevoEstado);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/estados")]
        public IActionResult updateEquipment([FromBody] estadoEquipos estadoToUpdate)
        {
            //obtener el registro original

            estadoEquipos estado = (from e in _contexto.estado_equipos
                                     where e.id_estados_equipo == estadoToUpdate.id_estados_equipo
                                     select e).FirstOrDefault();

            if (estado is null)
            {
                return NotFound();
            }

            estado.descripcion = estadoToUpdate.descripcion;


            _contexto.Entry(estado).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(estado);
        }

    }
}
