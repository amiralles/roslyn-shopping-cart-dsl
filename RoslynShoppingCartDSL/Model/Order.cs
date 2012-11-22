namespace RoslynShoppingCartDSL.Model {
    public class Order {
        public Order() {
            Customer = new Customer();
        }

        public Customer Customer { get; set; }
        public decimal TotalAmmount { get; set; }        
        public Country Country { get; set; }
        public bool Blocked { get; set; }
    }
}