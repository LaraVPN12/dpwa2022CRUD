using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2019LM606WACRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace _2019LM606WACRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public equiposController(prestamosContext miContexto)
        {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/equipos")]
        public IActionResult Get()
        {

            IEnumerable<equipos> equiposList = (from e in _contexto.equipos
                                                select e);


            if (equiposList.Count() > 0)
            {
                return Ok(equiposList);

            }

            return NotFound();
        }



        [HttpGet]
        [Route("api/equipos/{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            equipos equipo = (from e in _contexto.equipos
                              where e.id_equipos == idUsuario
                              select e).FirstOrDefault();

            if (equipo != null)
            {
                return Ok(equipo);

            }

            return NotFound();
        }

        [HttpPost]
        [Route("api/equipos")]
        public IActionResult guardarEquipo([FromBody] equipos nuevoEquipo)
        {
            try
            {
                _contexto.equipos.Add(nuevoEquipo);
                _contexto.SaveChanges();
                return Ok(nuevoEquipo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/equipos")]
        public IActionResult updateEquipment([FromBody] equipos equipmentToUpdate)
        {
            //obtener el registro original

            equipos equipment = (from e in _contexto.equipos
                                 where e.id_equipos == equipmentToUpdate.id_equipos
                                 select e).FirstOrDefault();

            if (equipment is null)
            {
                return NotFound();
            }

            equipment.nombre = equipmentToUpdate.nombre;
            equipment.descripcion = equipmentToUpdate.descripcion;

            _contexto.Entry(equipment).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(equipment);
        }



    }
}
