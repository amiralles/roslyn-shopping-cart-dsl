namespace RoslynShoppingCartDSL.UnitTets {
    using NUnit.Framework;
    using Scripting;

    [TestFixture]
    public class StringExtensionsFixture {

        [Test]
        public void convert_snake_case_to_pascal_case_test() {
            const string src      = "it_is_a_good_credit_customer";
            const string expected = "ItIsAGoodCreditCustomer";

            Assert.AreEqual(expected, src.ToPascalCase());
        }

        [Test]
        public void covnert_dsl_rule_to_chsarp_code() {
            const string dslSrc    = "when order_ammount_is < 100:";
            const string expected  = "if (OrderAmmountIs<100){\r\n}";

            Assert.AreEqual(expected, dslSrc.ToCSharp());
        }

        [Test]
        public void convert_dsl_rule_with_an_and_keyword_to_csharp() {
            const string dslSrc   = "when it_is_a_good_credit_customer and order_ammount_is > 10000:";
            const string expected = "if (ItIsAGoodCreditCustomer && OrderAmmountIs>10000){\r\n}";

            Assert.AreEqual(expected, dslSrc.ToCSharp());
        }

        [Test]
        public void convert_dsl_rule_with_condition_and_body() {
            const string dslSrc = "when it_is_a_good_credit_customer and order_ammount_is > 10000:\r\n" +
                "   apply_discount(10%)";

            const string expected = "if (ItIsAGoodCreditCustomer && OrderAmmountIs>10000){\r\n" +
                                    "ApplyDiscount(10);\r\n" +
                                    "}";

            Assert.AreEqual(expected, dslSrc.ToCSharp());
        }
    }
}