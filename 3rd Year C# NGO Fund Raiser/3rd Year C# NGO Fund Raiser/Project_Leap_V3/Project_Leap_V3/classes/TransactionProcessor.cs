using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Leap_V3
{
    /// <summary>
    /// Transaction processor 
    /// </summary>
    public class TransactionProcessor
    {
        /// <summary>
        /// private Variables
        /// </summary>
        private double amount;       
        private double amountToDonor;
        private double amountToSystem;
        private long npoID;

        /// <summary>
        /// No arg Constuctor
        /// </summary>
        public TransactionProcessor() { }

        /// <summary>
        /// Transactions to make payments
        /// </summary>
        /// <param name="amount">The Amount in the payment</param>
        public TransactionProcessor(double amount) 
        {
            this.amount = amount;
        }

        /// <summary>
        /// The Accessor and mutator of the Amount
        /// </summary>
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        /// <summary>
        /// The Accessor and mutator of the AmountToDonor
        /// </summary>
        public double AmountToDonor
        {
            get { return amountToDonor; }
            set { amountToDonor = value; }
        }
        /// <summary>
        /// The Accessor and mutator of the AmountToSystem
        /// </summary>
        public double AmountToSystem
        {
            get { return amountToSystem; }
            set { amountToSystem = value; }
        }
        /// <summary>
        /// The Accessor and mutator of the NpoID
        /// </summary>
        public long NpoID
        {
            get { return npoID; }
            set { npoID = value; }
        }

        /// <summary>
        /// Makeing Payment to a specific a NPO
        /// </summary>
        /// <param name="npoID"> NPO Id used for specifing which NPO to pay</param>
        /// <param name="amount">The Amount in the payment</param>
        public void ProcessTransaction(long npoID, double amount)
        {
            this.npoID = npoID;
            this.amount = amount;
        }
    }
}