using UnityEngine;

namespace MidtermExam.Prob01
{
    public class InventoryItem : ScriptableObject
    {
        [SerializeField]
        private string itemName = "New Item";

        [SerializeField]
        private float weight = 1f;

        [SerializeField]
        private int itemValue = 0;

        public string ItemName
        {
            get => itemName;
            set => itemName = value ?? string.Empty;
        }

        public float Weight
        {
            get => weight;
            set => weight = Mathf.Max(0f, value);
        }

        public int ItemValue
        {
            get => itemValue;
            set => itemValue = Mathf.Max(0, value);
        }

        
        public virtual bool Use(GameEntity user)
        {
            
            return false;
        }
    }
}
