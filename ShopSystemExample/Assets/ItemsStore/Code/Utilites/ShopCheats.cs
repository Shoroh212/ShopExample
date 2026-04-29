using ItemsStore.Code.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsStore.Code.Utilites
{
    public class ShopCheats : MonoBehaviour
    {
        public Button AddGoldButton;
        public Button RemoveGoldButton;

        private void Start()
        {
            AddGoldButton.onClick.AddListener(() => { WalletController.Instance.AddMoney(50); });
            RemoveGoldButton.onClick.AddListener(() => { WalletController.Instance.RemoveMoney(50); });
        }
    }
}
