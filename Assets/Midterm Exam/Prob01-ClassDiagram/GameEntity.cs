using UnityEngine;

namespace MidtermExam.Prob01
{
    public class GameEntity : MonoBehaviour
    {
        [SerializeField]
        private int id;

        [SerializeField]
        private Vector3 position;

        [SerializeField]
        private int health = 100;

        public int Id => id;

        public Vector3 Position
        {
            get => position;
            set
            {
                position = value;
                if (transform != null)
                {
                    transform.position = position;
                }
            }
        }

        public int Health => health;

        private void Awake()
        {
            
            if (transform != null)
            {
                position = transform.position;
            }
        }

        private void Update()
        {
           
            if (transform != null && transform.position != position)
            {
                position = transform.position;
            }

            
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {
            
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0) return;

            health = Mathf.Max(0, health - amount);

            if (health == 0)
            {
                OnDeath();
            }
        }

        protected virtual void OnDeath()
        {
            
            Destroy(gameObject);
        }

        public void Move(Vector3 delta)
        {
            Position += delta;
        }
    }
}
