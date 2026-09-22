using UnityEngine;

namespace MidtermExam.Prob01
{
    public class BossMonster : Monster
    {
        [SerializeField]
        private int phase = 1;

        [SerializeField]
        private bool isEnraged = false;

        public int Phase => phase;
        public bool IsEnraged => isEnraged;

       
        public override void Attack(GameEntity target, int damage = -1)
        {
            if (target == null) return;

            int damageToDeal = damage < 0 ? BaseDamage : damage;

            
            damageToDeal += (phase - 1) * 5;

            
            if (isEnraged)
            {
                damageToDeal = Mathf.RoundToInt(damageToDeal * 1.5f);
            }

            base.Attack(target, damageToDeal);
        }

        
        public override string Roar()
        {
            float originalAggro = AggroRange;
            
            AggroRange = Mathf.Min(AggroRange * 2.0f, 100f);

           
            isEnraged = true;

            return $"The boss roars! AggroRange {originalAggro} -> {AggroRange}. Enraged: {isEnraged}.";
        }

        
        public void TriggerPhaseTransition()
        {
            phase = Mathf.Max(1, phase + 1);

            
            BaseDamage = BaseDamage + 10;
            AggroRange = Mathf.Min(AggroRange + 3f, 100f);

            
            if (phase >= 3)
            {
                isEnraged = true;
            }
        }
    }
}
