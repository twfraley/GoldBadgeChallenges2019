using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimsRepository
    {
        Queue<Claim> claims = new Queue<Claim>();

        public void AddClaimToList(Claim claim)
        {
            claims.Enqueue(claim);
        }

        public Queue<Claim> GetClaims()
        {
            claims.Peek();
            return claims;
        }

        public void RemoveFirstItemFromList(Claim claim)
        {
            claims.Dequeue();
        }

    }
}