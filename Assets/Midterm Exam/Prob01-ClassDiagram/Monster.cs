using UnityEngine;

namespace MidtermExam.Prob01
{
    public class Monster : Character
    {
        [SerializeField]
        private int baseDamage = 15;

        [SerializeField]
        private float aggroRange = 5f;

        public int BaseDamage
        {
            get => baseDamage;
            set => baseDamage = Mathf.Max(0, value);
        }

        public float AggroRange
        {
            get => aggroRange;
            set => aggroRange = Mathf.Max(0f, value);
        }

       
        public override void Attack(GameEntity target, int damage = -1)
        {
            if (target == null) return;

            
            int damageToDeal = damage < 0 ? baseDamage : damage;

            
            if (Vector3.Distance(transform.position, target.Position) <= aggroRange)
            {
                base.Attack(target, damageToDeal);
            }
        }

        
        public virtual string Roar()
        {
            
            float originalAggro = aggroRange;
            aggroRange = Mathf.Min(aggroRange * 1.5f, 50f);

            
            return $"The monster roars, aggro range increased from {originalAggro} to {aggroRange}.";
        }
    }
}
