using Kols17022.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kols17022.DAL
{
    class WorkersDbService
    {
        private WorkersDb _contextDb = new WorkersDb();

        public IEnumerable<EMP> GetEmpList()
        {
            return _contextDb.EMPs.ToList();
        }

        public List<DEPT> GetDeptList()
        {
            return _contextDb.DEPTs.ToList();
        }

        public int GetMaxIndex()
        {
            return _contextDb.EMPs.Select(x => x.EMPNO).Max();
        }

        public void AddEMP(EMP emp)
        {
            _contextDb.EMPs.Add(emp);
            _contextDb.SaveChanges();
        }
    }
}
