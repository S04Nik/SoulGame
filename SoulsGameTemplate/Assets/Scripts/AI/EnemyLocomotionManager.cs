using UnityEngine;
using UnityEngine.AI;

namespace DarkSoul
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        public LayerMask detectionLayer;
        EnemyManager enemyManager;
        EnemyAnimatorManager enemyAnimatorManager;


        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
        }
    }
}
