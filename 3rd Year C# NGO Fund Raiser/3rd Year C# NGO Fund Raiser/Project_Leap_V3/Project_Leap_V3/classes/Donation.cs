using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// This class handles all donations
    /// </summary>
    public class Donation
    {
        /// <summary>
        /// These are the private variable declarations
        /// </summary>
        private double amount;
        private string equipmentName;  
        private string description;
        private long npoID;
        private TransactionProcessor transProcessor;

        /// <summary>
        /// This is the no-args constructor for the Donation class
        /// </summary>
        public Donation() 
        {
            transProcessor = new TransactionProcessor();
        }

        /// <summary>
        /// This is the Accessor and Mutator method for the Amount variable
        /// </summary>
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// This is the Accessor and Mutator method for the EquipmentName variable
        /// </summary>
        public string EquipmentName
        {
            get { return equipmentName; }
            set { equipmentName = value; }
        }

        /// <summary>
        /// This is the Accessor and Mutator method for the Description variable
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// This is the Accessor and Mutator method for the NpoID variable
        /// </summary>
        public long NpoID
        {
            get { return npoID; }
            set { npoID = value; }
        }

        /// <summary>
        /// This is the method that donates the money
        /// </summary>
        /// <param name="amount">The amount donated</param>
        /// <param name="npoID">The NPO that receives the donation</param>
        public void DonateMoney(double amount, long npoID) 
        { 
        
        }

        /// <summary>
        /// This is the method that donates the equipment
        /// </summary>
        /// <param name="equipmentName">The name of the equipment donated</param>
        /// <param name="equipmentValue">The amount of equipment donated</param>
        /// <param name="npoID">The NPO that receives the donation</param>
        public void DonateEquipment(string equipmentName, double equipmentValue, long npoID)
        { 
        
        }

        /// <summary>
        /// This method sends proof of donation
        /// </summary>
        public void SendDonationProof()
        { 
        
        }

        /// <summary>
        /// This method starts the donation request
        /// </summary>
        public void StartDonationRequest() 
        {
        
        }
    }
}