using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JSLTeste.Models;
using System.Web.Http.Description;
using System.Text;

namespace JSLTeste.Controllers
{
    public class TruckDriversController : Controller
    {
        private readonly JSLTruckerContext _context;

        public TruckDriversController(JSLTruckerContext context)
        {
            _context = context;
        }

        // GET: TruckDrivers
        /// <summary>
        /// Get the list of truck drivers
        /// </summary>
        /// <returns>
        /// List of TruckDriver object
        /// </returns>
        [Route("/TruckDrivers")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var jSLTruckerContext = _context.TruckDriver.Include(t => t.Address).Include(t => t.Truck);
                return Ok(await jSLTruckerContext.ToListAsync());
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Error get truck drivers", log = ex.Message });
            }
        }

        // GET: TruckDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckDriver = await _context.TruckDriver
                .Include(t => t.Address)
                .Include(t => t.Truck)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truckDriver == null)
            {
                return NotFound();
            }

            return Ok (truckDriver);
        }


        // POST: TruckDrivers/Create
        /// <summary>
        /// Create a new truck driver
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// {
        ///    "Name": "Renato",
        ///    "LastName":"Rossetti",
        ///    "Truck":{
        ///        "Model":"Atego 2425",
        ///        "Brand":"Mercedes",
        ///        "License":"ABC-123",
        ///        "Axle":6
        ///
        ///    },
        ///     "Address":{
        ///        "Street":"Rua Luiz da Silva Pires",
        ///        "Coordenates":"Automatic generated",
        ///        "Number":1450,
        ///        "City": "Mogi das Cruzes"
        ///
        ///    }
        ///}
        ///
        /// </remarks>
        /// <param name="truckDriver"></param>
        /// <returns>
        /// The object created
        /// </returns>
        [Route("/TruckDrivers/Create")]
        [HttpPost]
        [ResponseType(typeof(TruckDriver))]
        public async Task<IActionResult> Create([FromBody] TruckDriver truckDriver)
        {
            try
            {
                GoogleMapsAPI mapsApi = new GoogleMapsAPI();
                truckDriver.Address.Coordenates = mapsApi.GetAddressCoordenates(mapsApi.GetAddressFromTruckDriverObject(truckDriver));
                _context.Add(truckDriver.Address);
                _context.Add(truckDriver.Truck);
                _context.SaveChanges();
                _context.Add(truckDriver);
                await _context.SaveChangesAsync();
                return Ok(truckDriver);

            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Error to create driver", log = ex.Message });
            }
        }

        // PUT: TruckDrivers/Edit/5
        /// <summary>
        /// Edit a truck driver
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// {
        ///    "id":4
        ///    "Name": "Renato",
        ///    "LastName":"Rossetti",
        ///    "truckId": 7,
        ///        "adressId": 7,
        ///    "Truck":{
        ///        "Model":"Ford 123",
        ///        "Brand":"Ford",
        ///        "License":"ABC-123",
        ///        "Axle":7
        ///
        ///    },
        ///     "Address":{
        ///        "Street":"Rua Bras Cubas",
        ///        "Coordenates":"Automatic generated",
        ///        "Number":500,
        ///        "City": "Mogi das Cruzes"
        ///
        ///    }
        ///}
        ///
        /// </remarks>
        /// <param name="truckDriver"></param>
        ///  <param name="id"></param>
        /// <returns>
        /// The object edited
        /// </returns>
        [HttpPut]
        [Route("/TruckDrivers/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] TruckDriver truckDriver)
        {
            if (id != truckDriver.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(truckDriver);
                    GoogleMapsAPI mapsApi = new GoogleMapsAPI();
                    truckDriver.Address.Coordenates = mapsApi.GetAddressCoordenates(mapsApi.GetAddressFromTruckDriverObject(truckDriver));
                    _context.Update(truckDriver.Address);
                    _context.Update(truckDriver.Truck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckDriverExists(truckDriver.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            return Ok(truckDriver);
        }



        /// <summary>
        /// Delete truck driver
        /// </summary>
        ///  <param name="id"></param>
        /// <returns>
        /// TRUE OR FALSE
        /// </returns>
        [HttpDelete]
        [Route("/TruckDrivers/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var truckDriver = await _context.TruckDriver
                    .Include(t => t.Address)
                    .Include(t => t.Truck)
                    .FirstOrDefaultAsync(m => m.Id == id);
                _context.TruckDriver.Remove(truckDriver);
                _context.Address.Remove(truckDriver.Address);
                _context.Truck.Remove(truckDriver.Truck);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch(Exception ex)
            {
                return Json(new { status = "error", message = "Error delete driver", log=ex.Message });
            }
        }

        private bool TruckDriverExists(int id)
        {
            return _context.TruckDriver.Any(e => e.Id == id);
        }
    }
}
