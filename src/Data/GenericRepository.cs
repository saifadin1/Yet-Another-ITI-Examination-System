using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Data.Interfaces;

namespace Yet_Another_Examination_System.Data
{
    internal class GenericRepository<T> : IRepository<T> where T : ICloneable, IComparable<T>
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }
    }
}
