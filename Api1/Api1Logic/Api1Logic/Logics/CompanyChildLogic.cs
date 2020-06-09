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
    public class CompanyChildLogic
    {
        private readonly Api1Context _context;

        public CompanyChildLogic(Api1Context context)
        {
            _context = context;
        }

        public async Task UpdateData(List<CompanyChild> companyChildren, DateTime tsStamp, string usStamp, string asStamp)
        {
            companyChildren.ForEach(a =>
            {
                a.SetBaseData(tsStamp, usStamp, asStamp);
                _context.Entry(a).State = EntityState.Modified;
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task CreateData(List<CompanyChild> companyChildren, DateTime tsStamp, string usStamp, string asStamp)
        {
            companyChildren.ForEach(a =>
            {
                a.SetBaseData(tsStamp, usStamp, asStamp);
                _context.Entry(a).State = EntityState.Added;
            });

            await _context.SaveChangesAsync();
        }
    }
}
