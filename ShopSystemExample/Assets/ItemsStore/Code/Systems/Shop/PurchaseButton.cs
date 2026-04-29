using ItemsStore.Code.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsStore.Code.Systems.Shop
{

    [RequireComponent(typeof(Button))]
    public class PurchaseButton : MonoBehaviour
    {
        [Header("Button components")]
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;

        [Header("Image components")]
        public Image _itemImage;

        [Header("Item data")]
        [SerializeField] private ItemData _itemData;

        private void OnValidate()
        {
            _button ??= GetComponent<Button>();

            if (_itemData != null && _itemImage != null)
            {
                _itemImage.sprite = _itemData.ItemSprite;
            }
        }

        private void Start()
        {
            _button.onClick.AddListener(TryEquipOrPurchaseItem);
            _itemData.OnUnlocked.AddListener(UpdateView);
            SelectedItemController.Instance.SelectedItemData.OnValueChanged.AddListener((a,b) => UpdateView());
            WalletController.Instance.Money.OnValueChanged.AddListener((a,b) => UpdateView());

            UpdateView();
        }

        public void UpdateView()
        {
            _itemImage.sprite = _itemData.ItemSprite;
            string text = string.Empty;

            if (_itemData.IsUnlocked)
            {
                
                var isSelected = SelectedItemController.Instance.SelectedItemData.Value == _itemData;

                text = isSelected ? "Selected" : "Select";
                _button.interactable = !isSelected;
                _button.image.color = Color.gray;
            }
            else
            {
                text = $"Purchase ${_itemData.ShopCost}";
                _button.interactable = WalletController.Instance.Money.Value >= _itemData.ShopCost;
                _button.image.color = Color.black;
            }

            _buttonText.SetText(text);
        }

        public void TryEquipOrPurchaseItem()
        {
            if (_itemData.IsUnlocked)
            {
                SelectedItemController.Instance.SetNewItemSelected(_itemData);
            }
            else
            {
                TryPurchaseItem();
            }
        }


        public void TryPurchaseItem()
        {
            if (WalletController.Instance.TryPurchase(_itemData.ShopCost))
            {
                _itemData.Unlock();
                UnityEngine.Debug.Log($"Purchased {_itemData.ItemName}");
            }
            else
            {
                UnityEngine.Debug.Log("Not enought money");
            }
        }
    }
}
