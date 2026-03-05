using System;
using System.Collections.Generic;
using System.Text;

namespace Yet_Another_Examination_System.Data.Interfaces
{
    internal interface IRepository<T> where T : ICloneable, IComparable<T>
    {
            void Add(T item);
            void Remove(T item);
            IEnumerable<T> GetAll();
            void Sort();
    }
}
