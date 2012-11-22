namespace RoslynShoppingCartDSL.UnitTets {
    using Model;
    using NUnit.Framework;
    using Scripting;

    [TestFixture]
    public class EvalRulesFixture {

        /* Shopping cart DSL on Roslyn
           Samples:
            when is_a_bad_credit_customer and order_ammount_is > 10000:
                block_the_order
			 
            when is_a_good_credit_customer and order_ammount_is > 10000:
                apply_discount(10%)
			 
            when is_international_order:				
                add_shipping_fee($10)
         */

        [Test]
        public void when_an_order_is_international_should_add_shipping_fees() {
            const string src =
				"when is_international_order:\r\n" +
                "   add_shipping_fee $10";

            var dsl = new ShoppingCartScriptEngine(new Order { TotalAmmount = 99, Country = Country.Grece });
            dsl.Eval(src);
            Assert.AreEqual(109d, dsl.OrderAmmountIs);
        }


        [Test]
        public void when_order_ammount_is_greater_than_10000_and_is_a_good_credit_customer_apply_10_percent_discount() {
            const string src =
				"when is_a_good_credit_customer and order_ammount_is > 10000:\r\n" +
                "   apply_discount 10%";

            var dsl = new ShoppingCartScriptEngine(new Order { TotalAmmount = 11 * 1000 });
            dsl.Eval(src);

            Assert.AreEqual(9900, dsl.OrderAmmountIs);
        }

        [Test]
        public void when_is_a_bad_credit_customer_and_order_ammount_is_greater_than_10000_should_block_the_order() {
            const string src=
                "when is_a_bad_credit_customer and order_ammount_is > 10000:\r\n" +
                "   block_the_order";

            var dsl = new ShoppingCartScriptEngine(
                new Order {
                    Customer = new Customer { CreditLine = CustomerCreditLine.Bad },
                    TotalAmmount = 11 * 1000
                });

            dsl.Eval(src);

            Assert.IsTrue(dsl.OrderIsBlocked);
        }
    }
}
