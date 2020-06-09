using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api1.Api1Model.Models;
using Api1.Api1Model.Data;
using Common.CommonLogic.Logics;

namespace Api1.Api1Logic.Logics
{
    public class CompanyLogic
    {
        private readonly Api1Context _context;

        public CompanyLogic(Api1Context context)
        {
            _context = context;
        }

        public async Task<List<Company>> ReadDatas()
        {
            var company = _context.Company
                .Include(n => n.CompanyParentChilds)
                .Include(n => n.CompanyChildChilds);

            return await company.ToListAsync();
        }
        public async Task<Company> ReadData(int id)
        {
            var company = _context.Company
                .Include(n => n.CompanyParentChilds)
                .Include(n => n.CompanyChildChilds);

            return await company.FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task UpdateData(Company company, DateTime tsStamp, string usStamp, string asStamp)
        {
            company.SetBaseData(tsStamp, usStamp, asStamp);
            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                CompanyChildLogic companyChildLogic = new CompanyChildLogic(_context);
                await companyChildLogic.UpdateData(company.CompanyParentChilds, tsStamp, usStamp, asStamp);
                await companyChildLogic.UpdateData(company.CompanyChildChilds, tsStamp, usStamp, asStamp);

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task CreateData(Company company, DateTime tsStamp, string usStamp, string asStamp)
        {
            company.SetBaseData(tsStamp, usStamp, asStamp);
            _context.Entry(company).State = EntityState.Added;

            await _context.SaveChangesAsync();

            CompanyChildLogic companyChildLogic = new CompanyChildLogic(_context);
            await companyChildLogic.CreateData(company.CompanyParentChilds, tsStamp, usStamp, asStamp);
            await companyChildLogic.CreateData(company.CompanyChildChilds, tsStamp, usStamp, asStamp);

        }

        public async Task<Company> DeleteData(int id)
        {
            var company = await _context.Company.FindAsync(id);

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public bool Exists(int id)
        {
            return _context.Company.Any(p => p.CompanyId == id);
        }
    }
}
