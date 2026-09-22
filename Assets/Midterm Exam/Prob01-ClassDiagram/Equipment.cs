using UnityEngine;

namespace MidtermExam.Prob01
{
    [CreateAssetMenu(fileName = "NewEquipment", menuName = "MidtermExam/Inventory/Equipment")]
    public class Equipment : InventoryItem
    {
        [SerializeField]
        private int durability = 100;

        [SerializeField]
        private bool isEquipped = false;

        public int Durability
        {
            get => durability;
            set => durability = Mathf.Max(0, value);
        }

        public bool IsEquipped => isEquipped;

        
        public virtual bool Equip(GameEntity wearer, bool equip = true)
        {
            if (wearer == null) return false;

            if (isEquipped == equip) return false;

            isEquipped = equip;
            
            return true;
        }

        
        public override bool Use(GameEntity user)
        {
            if (user == null) return false;

            
            bool result = Equip(user, !isEquipped);
            return result;
        }
    }
}
