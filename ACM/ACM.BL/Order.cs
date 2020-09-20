using System;

namespace ACM.BL {
    public class Order {
        public Order () {

        }
        public Order (int orderId) {
            OrderId = orderId;
        }
        public int OrderId { get; set; }
        public DateTimeOffset? OrdareDate { get; set; }

        public Order Retrieve (int orderId) {
            return new Order ();
        }
        public bool Save () {
            return true;
        }
        public bool Validate () {
            var isValid = true;
            if (OrdareDate == null) isValid = false;
            return isValid;
        }

    }
}