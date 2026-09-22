using UnityEngine;

namespace MidtermExam.Prob01
{
    public class Mage : Character
    {
        [SerializeField]
        private int mana = 100;

        [SerializeField]
        private int spellPower = 5;

        public int Mana
        {
            get => mana;
            set => mana = Mathf.Max(0, value);
        }

        public int SpellPower => spellPower;

        
        public override void Attack(GameEntity target, int damage = 10)
        {
            if (target == null) return;

            const int preferredManaCost = 10;
            if (mana >= preferredManaCost)
            {
                
                CastSpell(target, manaCost: preferredManaCost, baseDamage: damage + 10);
            }
            else
            {
                
                base.Attack(target, damage);
            }
        }

        
        public bool CastSpell(GameEntity target, int manaCost = 10, int baseDamage = 25)
        {
            if (target == null) return false;
            if (mana < manaCost) return false;

            mana = Mathf.Max(0, mana - manaCost);

            int totalDamage = Mathf.Max(0, baseDamage + spellPower);
            target.TakeDamage(totalDamage);

            return true;
        }
    }
}
