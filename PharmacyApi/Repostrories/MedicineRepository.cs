using Microsoft.EntityFrameworkCore;
using Pharmacy.Interface;
using PharmacyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyApi.Repostrory
{
    public class MedicineRepository : MedicineInterface
    {

        private readonly PharmacyDataContext _context;
        public MedicineRepository(PharmacyDataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// ////////////////  Medicines
        /// </summary>
        /// 
        public async Task<Medicine> GetMedicine(int medicineId)
        {
            return await _context.Medicines
                .Include(i => i.ManufactureCompany)
                .FirstOrDefaultAsync(i => i.Id == medicineId);
        }
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _context.Medicines.Include(i=>i.ManufactureCompany).ToListAsync();
        }
        public async Task<Medicine> AddMedicine(Medicine medicine)
        {
            var Result = await _context.Medicines.AddAsync(medicine);
            await _context.SaveChangesAsync();
            return Result.Entity;
        }
        public async Task<Medicine> UpdateMedicine(Medicine medicine)
        {
            var Result = await _context.Medicines
                    .FirstOrDefaultAsync(i => i.Id == medicine.Id);
            if (Result != null)
            {
                Result.Title = medicine.Title;
                Result.Description = medicine.Description;
                Result.Image = medicine.Image;
                Result.Price = medicine.Price;
                Result.ManufactureCompanyId = medicine.ManufactureCompanyId;
                await _context.SaveChangesAsync();
                return Result;
            }
            return null;
        }
        public async Task<Medicine> DeleteMedicine(int medicineId)
        {
            var Result = await _context.Medicines
                   .FirstOrDefaultAsync(i => i.Id == medicineId);

            if (Result != null)
            {
                _context.Medicines.Remove(Result);
                await _context.SaveChangesAsync();
                return Result;
            }
            return null;
        }
        public async Task<IEnumerable<Medicine>> SearchMedicine(string Value)
        {
            var Result = await _context.Medicines
                .Where(i => i.Title == Value || i.Description.Contains(Value)).ToListAsync();
            if (Result != null)
            {
                return Result;
            }
            return null;
        }

        /// <summary>
        /// ////////////////  Manufacture Companies
        /// </summary>
        /// 
        public async Task<ManufactureCompany> AddCompany(ManufactureCompany company)
        {
            var Result = await _context.ManufactureCompanies.AddAsync(company);
            await _context.SaveChangesAsync();
            return Result.Entity;
        }
        public async Task<ManufactureCompany> GetCompany(int ID)
        {
            return await _context.ManufactureCompanies
              .FirstOrDefaultAsync(i => i.Id == ID);
        }
        public async Task<IEnumerable<ManufactureCompany>> GetCompanies()
        {
            return await _context.ManufactureCompanies
           .ToListAsync();
        }
        public async Task<ManufactureCompany> UpdateCompany(ManufactureCompany company)
        {
            var Result = await _context.ManufactureCompanies
                  .FirstOrDefaultAsync(i => i.Id == company.Id);
            if (Result != null)
            {
                Result.Value = company.Value;
                await _context.SaveChangesAsync();
                return Result;
            }
            return null;
        }
        public async Task<ManufactureCompany> DeleteCompany(int companyId)
        {
            var Result = await _context.ManufactureCompanies
                   .FirstOrDefaultAsync(i => i.Id == companyId);
            if (Result != null)
            {
                _context.ManufactureCompanies.Remove(Result);
                await _context.SaveChangesAsync();
                return Result;
            }
            return null;
        }

      

       
    }
}
