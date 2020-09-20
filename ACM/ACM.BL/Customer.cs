using System;
using System.Collections.Generic;

namespace ACM.BL {
    public class Customer {
        public Customer () {

        }
        public Customer (int customerId) {
            CustomerId = customerId;
        }
        public int CustomerId { get; private set; }
        public string EmailAddress { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName {
            get {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace (FirstName)) {
                    if (!string.IsNullOrWhiteSpace (fullName)) {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
        public static int InstanceCount { get; set; }

        public bool Validate () {
            var isValid = true;
            if (string.IsNullOrWhiteSpace (LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace (EmailAddress)) isValid = false;
            return isValid;
        }

        public Customer Retrieve (int customerId) {
            return new Customer ();
        }
        public List<Customer> Retrive () {
            return new List<Customer> ();
        }
        public bool Save () {
            return true;
        }

    }
}