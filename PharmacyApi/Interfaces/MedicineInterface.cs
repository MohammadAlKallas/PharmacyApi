using PharmacyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Interface
{
   public interface MedicineInterface
    {
        /*********** Product ***********/
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetMedicine(int medicineId);
        Task<Medicine> AddMedicine(Medicine medicine);
        Task<Medicine> UpdateMedicine(Medicine medicine);
        Task<Medicine> DeleteMedicine(int medicineId);
        Task<IEnumerable<Medicine>> SearchMedicine(string Value);

        /*********** Category ***********/
        Task<IEnumerable<ManufactureCompany>> GetCompanies();
        Task<ManufactureCompany> GetCompany(int companyId);
        Task<ManufactureCompany> AddCompany(ManufactureCompany company);
        Task<ManufactureCompany> UpdateCompany(ManufactureCompany company);
        Task<ManufactureCompany> DeleteCompany(int companyId);

       
    }
}
