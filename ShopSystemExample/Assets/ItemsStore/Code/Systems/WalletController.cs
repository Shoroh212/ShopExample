using Assets.ItemsStore.Code.Utilites;
using ItemStore.Code.Utility;
using System;

namespace ItemsStore.Code.Systems
{
    public class WalletController : Singleton<WalletController>
    {
        public PlayerPrefsInt Money { get; private set; } = new("PlayerBalance");
        private PlayerPrefsInt _isEnterFirstTime = new("FirstEntrance");

        private void Start()
        {
            if (_isEnterFirstTime.Value == 0)
            {
                _isEnterFirstTime.Value = 1;
                Money.Value = 300;
            }
        }

        public bool TryPurchase(int Cost)
        {
            if (Money.Value >= Cost)
            {
                RemoveMoney(Cost);
                return true;
            }

            return false;
        }

        public void RemoveMoney(int amount)
        {
            Money.Value -= amount;
            if (Money.Value < 0) Money.Value = 0;
        }

        public void AddMoney(int amount)
        {
            Money.Value += amount;
        }
    }
}
