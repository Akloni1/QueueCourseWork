using System.Collections.Generic;

namespace Consumer.Models
{
    public class BankAccount
    {
        public long Id { get; set; }
        public string NumberBankCard { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
    }

    public static class BankAccounts
    {
        public static IList<BankAccount> Accounts = new List<BankAccount>
            {
               new BankAccount{ Id = 1, Balance= 5000, FullName= "Юхансон Михаил Ларсович", NumberBankCard = "0000000000000001"},
               new BankAccount{ Id = 2, Balance= 10000, FullName= "Екатерина Антонова", NumberBankCard = "0000000000000002"},
               new BankAccount{ Id = 3, Balance= 5000, FullName= "Новопашенный Максим Витальевич", NumberBankCard = "0000000000000003"},
               new BankAccount{ Id = 4, Balance= 10000, FullName= "Карпухин Михаил Андреевич", NumberBankCard = "0000000000000004"},
            };
    }
}
