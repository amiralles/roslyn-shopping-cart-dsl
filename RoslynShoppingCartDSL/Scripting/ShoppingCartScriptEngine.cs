namespace RoslynShoppingCartDSL.Scripting {
    using System;
    using System.Reflection;
    using System.Text;
    using Model;
    using Roslyn.Scripting.CSharp;

    public class ShoppingCartScriptEngine {
        readonly ScriptEngine _engine;

        public ShoppingCartScriptEngine(Order order) {
            if (order == null)
                throw new ArgumentNullException("order", "cannot be null");

            Order = order;
            _engine = new ScriptEngine();
        }

        public Order Order { get; private set; }

        public decimal OrderAmmountIs {
            get {
                return Order.TotalAmmount;
            }
        }

        public bool IsAGoodCreditCustomer {
            get {
                return Order.Customer.CreditLine == CustomerCreditLine.Good;
            }
        }

        public bool IsABadCreditCustomer {
            get {
                return Order.Customer.CreditLine == CustomerCreditLine.Bad;
            }
        }

        public bool IsInternationalOrder { 
            get { 
                return Order.Country != Country.Argentinga; 
            }
        }

        public bool OrderIsBlocked {
            get { 
                return Order.Blocked; 
            }
        }

        public void AddShippingFee(decimal ammount) {
            Order.TotalAmmount += ammount;
        }

        public void ApplyDiscount(decimal percent) {
            Order.TotalAmmount -= Order.TotalAmmount * percent / 100;
        }

        public void BlockTheOrder() {
            Order.Blocked = true;
        }

        public void Eval(string src) {
            var session = _engine.CreateSession(this, typeof(ShoppingCartScriptEngine));
            session.AddReference(Assembly.Load(typeof(ShoppingCartScriptEngine).Assembly.GetName()));
            session.Execute(Prepare(src).ToCSharp());
        }

        internal string Prepare(string src) {
            var result = new StringBuilder();
            var closeParen = false;

            //add parenthesis when needed
            for (var i = 0; i < src.Split(' ').Length; i++) {
                var chunk = src.Split(' ')[i];
                if (ContainsMethod(chunk)) {
                    result.Append(chunk + "(");
                    closeParen = true;
                }
                else if (closeParen) {
                    //this is safe because we only support up to one argument methods.
                    result.Append(chunk + ")");
                    closeParen = false;
                }
                else {
                    result.Append(chunk + " ");
                }
            }

            if (closeParen)
                result.Append(")");

            return result.ToString();
        }

        private bool ContainsMethod(string methodName) {
            return GetType().GetMethod(methodName.ToPascalCase()) != null;
        }
    }
}