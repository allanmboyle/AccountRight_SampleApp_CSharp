﻿//  File:        JournalLineModel.cs
//  Copyright:   Copyright 2012 MYOB Technology Pty Ltd. All rights reserved.
//  Website:     http://www.myob.com
//  Author:      MYOB
//  E-mail:      info@myob.com
//
//Documentation, code and sample applications provided by MYOB Australia are for 
//information purposes only. MYOB Technology Pty Ltd and its suppliers make no 
//warranties, either express or implied, in this document. 
//
//Information in this document or code, including website references, is subject
//to change without notice. Unless otherwise noted, the example companies, 
//organisations, products, domain names, email addresses, people, places, and 
//events are fictitious. 
//
//The entire risk of the use of this documentation or code remains with the user. 
//Complying with all applicable copyright laws is the responsibility of the user. 
//
//Copyright 2012 MYOB Technology Pty Ltd. All rights reserved.
using Newtonsoft.Json;

namespace CSharpSamples.GeneralJournal.Models
{
    public class JournalLineModel
    {
        public long RowVersion { get; set; }

        public int RowId { get; set; }

        /// <summary>
        ///   Account Number
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        ///   Account Name - Read Only
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        ///   Debit
        /// </summary>
        [JsonIgnore]
        public decimal Debit
        {
            get { return IsCredit ? 0 : Amount; }
            set
            {
                if (value != 0)
                {
                    IsCredit = false;
                    Amount = value;
                }
            }
        }

        /// <summary>
        ///   Credit
        /// </summary>
        [JsonIgnore]
        public decimal Credit
        {
            get { return IsCredit ? Amount : 0; }
            set
            {
                if (value != 0)
                {
                    IsCredit = true;
                    Amount = value;
                }
            }
        }

        /// <summary>
        ///   Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// IsCredit
        /// </summary>
        public bool IsCredit { get; set; }

        /// <summary>
        ///   Job Id
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        ///   Memo
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        ///  Tax Code
        /// </summary>
        public string TaxCodeId { get; set; }

        /// <summary>
        ///  Calculated TaxAmount - Read Only
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Override Tax Amount.
        /// </summary>
        public bool IsOverridenTaxAmount { get; set; }
    }
}