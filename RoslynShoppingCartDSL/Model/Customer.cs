namespace RoslynShoppingCartDSL.Model {
    public class Customer {
        public Customer() {
            CreditLine = CustomerCreditLine.Good;
        }

        public CustomerCreditLine CreditLine { get; set; }
    }
}