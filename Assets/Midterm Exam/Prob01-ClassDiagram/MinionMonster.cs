using UnityEngine;

namespace MidtermExam.Prob01
{
    public class MinionMonster : Monster
    {
        [SerializeField]
        private float swarmBonus = 1.5f;

        [SerializeField]
        private bool isAlerted = false;

        public float SwarmBonus
        {
            get => swarmBonus;
            set => swarmBonus = Mathf.Max(0f, value);
        }

        public bool IsAlerted => isAlerted;

        
        public bool CallReinforcements(float radius = 10f, int maxCalls = 3)
        {
            if (radius <= 0f || maxCalls <= 0) return false;

            Collider[] hits = Physics.OverlapSphere(transform.position, radius);
            int alertedCount = 0;

            foreach (var hit in hits)
            {
                if (alertedCount >= maxCalls) break;

                var other = hit.GetComponent<MinionMonster>();
                if (other == null || other == this) continue;

                other.isAlerted = true;
                other.AggroRange = Mathf.Min(other.AggroRange + swarmBonus, 100f);
                alertedCount++;
            }

            
            if (alertedCount > 0)
            {
                isAlerted = true;
                return true;
            }

            return false;
        }
    }
}
