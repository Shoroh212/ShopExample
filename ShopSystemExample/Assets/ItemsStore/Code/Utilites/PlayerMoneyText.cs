using ItemsStore.Code.Systems;
using TMPro;
using UnityEngine;

namespace Assets.ItemsStore.Code.Utilites
{

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PlayerMoneyText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerMoneyText;

        private void OnValidate()
        {
            _playerMoneyText ??= GetComponent<TextMeshProUGUI>();
        }

        private void Awake()
        {
            WalletController.Instance.Money.OnValueChanged.AddListener((oldValue, newValue) => UpdateView(newValue));
        }

        private void Start()
        {
            UpdateView(WalletController.Instance.Money.Value);
        }

        public void UpdateView(int PlayerMoneyAmount)
        {
            _playerMoneyText.SetText(PlayerMoneyAmount.ToString());
        }
    }
}
