namespace RoslynShoppingCartDSL.UnitTets {
    using Model;
    using NUnit.Framework;
    using Scripting;

    [TestFixture]
    public class PrepareSourceFixture {
        
        [Test]
        public void fix_parenthesis_for_argument_less_method() {
            const string src = "block_the_order";
            var engine = new ShoppingCartScriptEngine(new Order());
            Assert.AreEqual("block_the_order()", engine.Prepare(src));
        }

        [Test]
        public void fix_parenthesis_for_one_argument_method() {
            const string src = "apply_discount 10%";
            var engine = new ShoppingCartScriptEngine(new Order());
            Assert.AreEqual("apply_discount(10%)", engine.Prepare(src));
        }
    }
}