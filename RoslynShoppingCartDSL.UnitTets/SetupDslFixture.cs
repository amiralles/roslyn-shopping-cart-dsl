namespace RoslynShoppingCartDSL.UnitTets {
    using Model;
    using NUnit.Framework;
    using Scripting;

    [TestFixture]
    public class SetupDslFixture {
        [Test]
        public void after_the_dsl_is_configured_order_cannot_be_null() {
            var order = new Order();
            var dsl = new ShoppingCartScriptEngine(order);

            Assert.IsNotNull(dsl.Order);
        }

        [Test]
        public void dsl_order_ammount_should_be_equal() {
            var order = new Order();
            var dsl = new ShoppingCartScriptEngine(order);

            Assert.AreEqual(dsl.OrderAmmountIs, order.TotalAmmount);
        }
    }
}