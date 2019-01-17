using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class ClaimsRepository
    {
        //--------------------
        // change list to queue
        //--------------------

        List<Claim> claims = new List<Claim>();

        public void AddClaimToList(Claim claim)
        {
            claims.Add(claim);
        }

        public List<Claim> GetClaims()
        {
            return claims;
        }

        public void RemoveFirstItemFromList(Claim claim)
        {
            claims.RemoveAt(0);
        }

    }
}
