﻿using System;

namespace SteamAuth
{
    public class Confirmation
    {
        public string ID;
        public string Key;
        public string Description;

        public ConfirmationType ConfType
        {
            get
            {
                if (String.IsNullOrEmpty(Description)) return ConfirmationType.Unknown;
                if (Description.StartsWith("Confirm ")) return ConfirmationType.GenericConfirmation;
                if (Description.StartsWith("Trade with ")) return ConfirmationType.Trade;
                if (Description.StartsWith("Sell -")) return ConfirmationType.MarketSellTransaction;

                return ConfirmationType.Unknown;
            }
        }

        public enum ConfirmationType
        {
            GenericConfirmation = 0,
            Trade = 1,
            MarketSellTransaction = 2,
            Unknown = 3
        }
    }
}