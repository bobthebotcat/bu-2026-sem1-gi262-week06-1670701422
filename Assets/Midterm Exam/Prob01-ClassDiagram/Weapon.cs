using UnityEngine;

namespace MidtermExam.Prob01
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "MidtermExam/Inventory/Weapon")]
    public class Weapon : Equipment
    {
        [SerializeField]
        private int extraDamage = 5;

        [SerializeField]
        private float criticalChance = 0.1f;

        public int ExtraDamage
        {
            get => extraDamage;
            set => extraDamage = Mathf.Max(0, value);
        }

        public float CriticalChance
        {
            get => criticalChance;
            set => criticalChance = Mathf.Clamp01(value);
        }

       
        public override bool Equip(GameEntity wearer, bool equip = true)
        {
            
            bool changed = base.Equip(wearer, equip);
            if (!changed) return false;

            if (equip)
            {
                
                Durability = Mathf.Max(0, Durability - 1);

                
                if (Durability == 0)
                {
                    base.Equip(wearer, false);
                    return false;
                }
            }

            return true;
        }

       
        public void Polish(int extraDamageIncrease = 1, float critIncrease = 0.01f, int durabilityRestore = 5)
        {
            ExtraDamage += extraDamageIncrease;
            CriticalChance = Mathf.Clamp01(CriticalChance + critIncrease);
            Durability = Mathf.Min(Durability + durabilityRestore, 100);
        }
    }
}
