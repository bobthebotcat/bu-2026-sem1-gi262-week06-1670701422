using UnityEngine;

namespace MidtermExam.Prob01
{
    public class Character : GameEntity
    {
        [SerializeField]
        private string characterName = "New Character";

        [SerializeField]
        private float moveSpeed = 5f;

        [SerializeField]
        private int level = 1;

        public string CharacterName => characterName;
        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = Mathf.Max(0f, value);
        }
        public int Level => level;

        private void Start()
        {
            if (string.IsNullOrWhiteSpace(characterName))
            {
                characterName = gameObject.name;
            }
        }

        
        public virtual void Attack(GameEntity target, int damage = 10)
        {
            if (target == null) return;
            target.TakeDamage(damage);
        }

        
        public virtual void LevelUp()
        {
            level = Mathf.Max(1, level + 1);
            moveSpeed += 0.5f;
        }
    }
}
//                            /\              /\
  //                         /  \            /  \
    //                      /    \          /    \
      //                   /      \_______ /      \
        //                 |                      |
          //               |    \\\        ///    |
            //             |   \(O)        (O)/   |             ____
              //           |          I           |            /    \
                //         |          |           |            |    |
                  //       |      \__ /\___/      |            |    |
                    //      \___________________ / \___      _/   _/
                      //       |                       \    /    /
                        //     |      |                |___/    /
                          //   |      |         _______|      _/
                            // |      |        /       |_____/
 //                            |      |        |       |
   //                          |      |        |       |
     //                       /       /        /       |
       //                    |__|__|_/|__|__|_/|__|__|/                             


            //เห็นแก่แมวตัวน้อยๆด้วยนะครับ
