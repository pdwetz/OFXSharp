using System.IO;
using System.Linq;
using NUnit.Framework;

namespace OFXSharp.Tests
{
    [TestFixture]
    public class DocumentParserTests
    {
        [Test]
        public void Parse_Bank_Itau()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"itau.ofx");
            var parser = new OFXDocumentParser();
            var ofx = parser.Import(new FileStream(filePath, FileMode.Open));
            Assert.AreEqual("0341", ofx.Account.BankID);
            Assert.AreEqual("9999999999", ofx.Account.AccountID);
            Assert.AreEqual(BankAccountType.CHECKING, ofx.Account.BankAccountType);
            Assert.AreEqual(-9999.99m, ofx.Balance.LedgerBalance);
        }

        [Test]
        public void Parse_Bank_Santander()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"santander.ofx");
            var parser = new OFXDocumentParser();
            var ofx = parser.Import(new FileStream(filePath, FileMode.Open));
            Assert.AreEqual("00510367", ofx.Transactions.First().TransactionID.Trim());
        }

        [Test]
        public void Parse_CreditCard()
        {
            string filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"cc.ofx");
            var parser = new OFXDocumentParser();
            var ofx = parser.Import(new FileStream(filePath, FileMode.Open));
            Assert.AreEqual(3, ofx.Transactions.Count());
        }
    }
}