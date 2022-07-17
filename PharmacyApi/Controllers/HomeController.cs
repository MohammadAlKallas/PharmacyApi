using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyApi.Models;
using PharmacyApi.Repostrory;
using Microsoft.AspNetCore.Http;
using Pharmacy.Interface;

namespace PharmacyApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class HomeController : ControllerBase
    {

        public readonly MedicineInterface medicineRepository;
        public HomeController(MedicineInterface medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }
        /*********** Get All Medicine **********/
        [HttpGet("GetMedicines")]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()
        {
            try
            {
                return Ok(await medicineRepository.GetMedicines());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        /*********** Create New Medicine **********/
        [HttpPost("CreateMedicine")]
        public async Task<ActionResult<Medicine>> CreateMedicine(Medicine medicine)
        {
            try
            {
                if (medicine == null)
                {
                    return BadRequest();
                }
                var Result = await medicineRepository.AddMedicine(medicine);
                return CreatedAtAction(nameof(GetMedicines),
                new { Id = medicine.Id }, medicine);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }

        }

        /*********** Get One Medicine Details **********/
        [HttpGet("GetMedicineDetails/{ID}")]
        public async Task<ActionResult<Medicine>> GetMedicineDetails(int ID)
        {
            try
            {
                var Result = await medicineRepository.GetMedicine(ID);
                if (Result == null)
                {
                    return NotFound();
                }
                return Result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }

        /*********** Medicine Delete **********/
        [HttpDelete("MedicineDelete/{ID}")]
        public async Task<ActionResult<Medicine>> MedicineDelete(int ID)
        {
            try
            {
                var Result = await medicineRepository.GetMedicine(ID);
                if (Result == null)
                {
                    return NotFound($"Medicine ID ={ID} not  Found");
                }

                return await medicineRepository.DeleteMedicine(ID);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error Deleteing Data");
            }

        }

        /*********** Medicine Update **********/
        [HttpPut("MedicineUpdate")]
        public async Task<ActionResult<Medicine>> MedicineUpdate(Medicine medicine)
        {
            try
            {
                var Result = await medicineRepository.GetMedicine(medicine.Id);
                if (Result == null)
                {
                    return NotFound($"Medicine ID ={medicine.Id} not Found");
                }
                return await medicineRepository.UpdateMedicine(medicine);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error Updating Data");
            }


        }

        /*********** Medicine Search By Title OR Description **********/
        [HttpGet("MedicineSearch/{value}")]
        public async Task<ActionResult<IEnumerable<Medicine>>> MedicineSearch(string value)
        {
            try
            {
                var Result = await medicineRepository.SearchMedicine(value);
                if (Result == null)
                {
                    return NotFound();
                }
                return Ok(Result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error retrieving data from the database");
            }
        }


        /// <summary>
        /// //////////// Companies
        /// </summary>

        /*********** Get All Company **********/
        [HttpGet("GetCompanies")]
        public async Task<ActionResult> GetCompanies()
        {
            try
            {
                return Ok(await medicineRepository.GetCompanies());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        /*********** Create New Company **********/
        [HttpPost("CreateCompany")]
        public async Task<ActionResult<ManufactureCompany>> CreateCompany(ManufactureCompany company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest();
                }
                var Result = await medicineRepository.AddCompany(company);
                return CreatedAtAction(nameof(GetCompanies),
                new { Id = company.Id }, company);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                               "Error retrieving data from the database");
            }

        }

        /*********** Company Delete **********/
        [HttpDelete("CompanyDelete/{ID}")]
        public async Task<ActionResult<ManufactureCompany>> CompanyDelete(int ID)
        {
            try
            {
                var Result = await medicineRepository.GetCompany(ID);
                if (Result == null)
                {
                    return NotFound($"Company ID ={ID} not  Found");
                }

                return await medicineRepository.DeleteCompany(ID);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error Deleteing Data");
            }

        }

        /*********** Company Update **********/
        [HttpPut("CompanyUpdate/{ID}")]
        public async Task<ActionResult<ManufactureCompany>> CompanyUpdate(int ID, ManufactureCompany company)
        {
            try
            {
                if (ID != company.Id)
                {
                    return BadRequest("Company ID Mismatchg");
                }
                var Result = await medicineRepository.GetMedicine(ID);
                if (Result == null)
                {
                    return NotFound($"Company ID ={ID} not Found");
                }
                return await medicineRepository.UpdateCompany(company);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error Updating Data");
            }


        }

    }
}
