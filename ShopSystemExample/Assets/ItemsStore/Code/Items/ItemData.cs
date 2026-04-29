using System;
using UnityEngine;
using UnityEngine.Events;

namespace ItemsStore.Code.Items
{

    [CreateAssetMenu(fileName = "NewItem", menuName = "Game/WeaponData")]
    public class ItemData : ScriptableObject
    {
        [NonSerialized] public UnityEvent OnUnlocked = new();

        [Header("Item visuals")]
        public Sprite ItemSprite;
        public string ItemName;

        [Header("Store settings")]
        public int ShopCost;


        public bool IsUnlocked
        {
            get
            {
                return PlayerPrefs.HasKey(ItemName);
            }
        }

        public void Unlock()
        {
            PlayerPrefs.SetInt(ItemName, 0);

            OnUnlocked?.Invoke();
        }
    }
}
