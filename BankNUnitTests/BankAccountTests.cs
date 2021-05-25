using Bank;
using System;
using NUnit.Framework;


//Cambios para entrega

namespace BankNUnitTests
{
    public class BankAccountTests
    {
        private BankAccount account;
        private BankAccount otherAccount;
        private BankAccount noneAccount;

        [SetUp]
        public void Setup()
        {
            //Abro una nueva cuenta con fondos
            account = new BankAccount(1000);
            //Abro una segunda cuenta con fondos
            otherAccount = new BankAccount(1000);
            //Cuenta null
            noneAccount = null;
        }
        //1
        [Test]
        public void Test_Retiro_Fondos()
        {
            //Retiro fonsos
            account.Withdraw(500);
            //Controlo que se el balance es el correcto
            Assert.AreEqual(500, account.Balance);
        }
        //2
        [Test]
        public void Test_Agrego_Fondos()
        {
            //Agrego fondos
            account.Add(600);
            //Controlo que el balance es el correcto
            Assert.AreEqual(1600, account.Balance);
        }
        //3
        [Test]
        public void Test_Transferir_A_Otros()
        {
            //Transfiero a otra cuenta
            account.TransferFundsTo(otherAccount,100);

            //Controlo disminución en acc 1 y aumento en acc 2
            Assert.AreEqual(900,account.Balance);
            Assert.AreEqual(1100,otherAccount.Balance);
        }
        //4
        [Test]
        public void Test_Retiro_Negativo()
        {
            //Retiro de un número negativo
            //Como el error se ejecuta mediante un throw, realizo un assert conteniendo la función Withdraw
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        //5
        [Test]
        public void Test_Trn_Cuenta_Inexistente()
        {
            //Transfiero a una cuenta declarada como null
            //Como el error se ejecuta metiante un throw, realizo un asser contendiendo a la funcion TransferFundsTo
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(noneAccount, 100));
        }
    }
}