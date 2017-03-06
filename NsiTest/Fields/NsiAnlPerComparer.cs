using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NsiTest.Fields
{
    class NsiAnlPerComparer : IEqualityComparer<NsiAnlPer>
    {
        public bool Equals(NsiAnlPer x, NsiAnlPer y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Period == y.Period && x.Value == y.Value;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(NsiAnlPer pAnlPer)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(pAnlPer, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = pAnlPer.Value == null ? 0 : pAnlPer.Value.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = pAnlPer.Period.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }
    }
}
