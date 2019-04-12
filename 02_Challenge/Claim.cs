using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public enum ClaimType {  Car, Home, Theft}

    public class Claim
    {
        public int ClaimID {get;set;}
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool ClaimValid { get; set; }

        public Claim (int claimID, ClaimType claimType, string description, decimal amount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            ClaimValid = DateOfClaim - DateOfAccident < TimeSpan.FromDays(30);
        }

        public Claim()
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
