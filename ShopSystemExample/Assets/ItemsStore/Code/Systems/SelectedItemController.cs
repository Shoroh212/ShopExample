using ItemsStore.Code.Items;
using ItemsStore.Code.Utilites;
using ItemStore.Code.Utility;

namespace ItemsStore.Code.Systems
{
    public class SelectedItemController : Singleton<SelectedItemController>
    {
        public ReactiveField<ItemData> SelectedItemData { get; private set; } = new(null);

        public void SetNewItemSelected(ItemData item)
        {
            SelectedItemData.Value = item;
        }
    }
}
