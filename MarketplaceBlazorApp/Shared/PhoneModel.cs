using System;
using System.Collections.Generic;
using System.Text;

namespace MarketplaceBlazorApp.Shared
{
    public class PhoneModel
    {
        int phoneID;
        string number;
        int userID;

        public int PhoneID { get => phoneID; set => phoneID = value; }
        public string Number { get => number; set => number = value; }
        public int UserID { get => userID; set => userID = value; }
    }
}
