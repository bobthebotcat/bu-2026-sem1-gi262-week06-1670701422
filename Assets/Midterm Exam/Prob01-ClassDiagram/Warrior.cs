using UnityEngine;

namespace MidtermExam.Prob01
{
    public class Warrior : Character
    {
        [SerializeField]
        private int shieldDefense = 20;

        [SerializeField]
        private int rage = 0;

        public int ShieldDefense => shieldDefense;
        public int Rage => rage;

        
        public override void Attack(GameEntity target, int damage = 10)
        {
            if (target == null) return;

            
            int effectiveDamage = Mathf.Max(0, damage - 0); 
            base.Attack(target, effectiveDamage);

            
            rage += Mathf.Max(0, effectiveDamage / 2);
            rage = Mathf.Min(rage, 100); // clamp rage to 100
        }

        
        public bool ShieldBash(GameEntity target, int extraDamage = 25, int rageCost = 20)
        {
            if (target == null) return false;
            if (rage < rageCost) return false;

            rage -= Mathf.Max(0, rageCost);

            target.TakeDamage(extraDamage);

           
            if (target is Hero hero)
            {
                if (target.Health == 0)
                {
                    hero.CollectGold(5);
                }
            }

            return true;
        }
    }
}
