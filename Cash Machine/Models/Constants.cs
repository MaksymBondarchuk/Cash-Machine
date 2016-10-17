using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cash_Machine.Models
{
    public static class Constants
    {
        public static class OperationType
        {
            public static Guid Balance = new Guid("f9264538-5c2e-4f8e-be0c-e8640c3f8844");
            public static Guid GetCash = new Guid("ce2bf368-8b54-40da-84f7-9bc87f12badc");
        }
    }
}