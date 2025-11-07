using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS557DatabasePrj.BL
{
    public class Card : AuditableEntity
    {
        //Should CardNumber be the primary key for this table or a separate CardId?
        public string CardNumberMasked { get; set; } = "";//store masked PAN for UI; real PAN never stored here
        public CardType CardType { get; set; } = CardType.Debit;
        public DateTime ExpirationUtc { get; set; }
        public string CardholderName { get; set; } = "";
        public int AccountId { get; set; }// FK -> Account
        public int OwnerUserId { get; set; }// FK -> User

        public Account? Account { get; set; }
        public User? Owner { get; set; }
    }
}
