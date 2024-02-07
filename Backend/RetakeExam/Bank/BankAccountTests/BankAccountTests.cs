using Bank;

namespace BankAccountTests
{
    public class BankAccountTests
    {
        [Test]
        public void AmountDecimalPositovenumber()
        {
            var bankMoney = new BankAccount(400);

            decimal expected = 400;

            decimal actual = bankMoney.Amount;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AmountDecimalNegatovenumber()
        {

            try
            {
                BankAccount bankAccount = new BankAccount(-300);
            }
            catch (ArgumentException exception)
            {
                string message = "Amount cannot be negative!";
                Console.WriteLine(exception);
                Assert.That(exception.Message, Is.EqualTo(message));
            }
        }

        [Test]
        public void TestDeposit()
        {

            BankAccount bankAccount = new BankAccount(400);

            bankAccount.Deposit(1000);

            Assert.That(bankAccount.Amount, Is.EqualTo(1400));
        }
        [Test]
        public void TestDepositNegative()
        {
           
            BankAccount bankMoney = new BankAccount(450);

            string message = "Deposit cannot be negative or zero!";

            var exception = Assert.Throws<ArgumentException>(() => bankMoney.Deposit(-100));
            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void TestWithdrow()
        {
           
            BankAccount bankMoney = new BankAccount(400);

            string message = "Withdrawal exceeds account balance!";

            var exception = Assert.Throws<ArgumentException>(() => bankMoney.Withdraw(800));
            Assert.That(exception.Message, Is.EqualTo(message));

        }
        [Test]
        public void TestWithdrawWithFee() 
        {
            BankAccount bankMoney = new BankAccount(1000);

            bankMoney.Withdraw(200);

            Assert.That(bankMoney.Amount, Is.EqualTo(796));
        }
        [Test]
        public void TestWithdrawNegative() 
        {
    
            BankAccount bankMoney = new BankAccount(400);


            string message = "Withdrawal cannot be negative or zero!";

            var exception = Assert.Throws<ArgumentException>(() => bankMoney.Withdraw(-500));
            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
