using UnityEngine;

namespace MidtermExam.Prob01
{
    public class Hero : Character
    {
        [SerializeField]
        private int currentExp = 0;

        [SerializeField]
        private int gold = 0;

        public int CurrentExp => currentExp;
        public int Gold => gold;

        
        public override void Attack(GameEntity target, int damage = 10)
        {
            if (target == null) return;

            
            base.Attack(target, damage);

           
            currentExp += Mathf.Max(0, damage);

            
            if (target.Health == 0)
            {
                currentExp += 50; 
                CollectGold(10);  
            }
        }

        
        public void CollectGold(int amount)
        {
            if (amount <= 0) return;
            gold += amount;
        }

        
        public override void LevelUp()
        {
            base.LevelUp();

            
            currentExp = 0;

            
            CollectGold(20);
        }
    }
}
