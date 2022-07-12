using System;
using UnityEngine;
using UnityEngine.AI;

namespace DarkSoul
{
    public class EnemyManager : CharacterManager
    {
        public bool isPerformingAction;
        public bool isInteracting;

        [Header("A.I. Settings")]
        public float detectionRadius = 20;
        public float minimumDetectionAngle = -50;
        public float maximumDetectionAngle = 50;
        public float viewableAngle;
        public float rotationSpeed = 20f;
        public float maximumAttackRange = 1.5f;
        public float distanceFromTarget;
        public float currentRecoveryTime = 0;
        public State currentState;
        public CharacterStats currentTarget;
        public Rigidbody enemyRigidBody;
        public NavMeshAgent navMeshAgent;
        EnemyLocomotionManager locomotionManager;
        EnemyAnimatorManager animatorManager;
        EnemyStats enemyStats;

        private void Awake()
        {
            locomotionManager = GetComponent<EnemyLocomotionManager>();
            animatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            enemyRigidBody = GetComponent<Rigidbody>();
            enemyStats = GetComponent<EnemyStats>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }
        private void Start()
        {
            navMeshAgent.enabled = false;
            enemyRigidBody.isKinematic = false;
        }
        private void Update()
        {
            HandleRecoveryTimer();

            isInteracting = animatorManager.anim.GetBool("isInteracting");
        }

        private void FixedUpdate()
        {
            // rigid body moves better here
            // less memory intensive
            HandleStateMachine();

        }

        private void HandleStateMachine()
        {
            if(currentState != null)
            {
                State nextState = currentState.Tick(this,enemyStats,animatorManager);

                if(nextState != null)
                {
                    SwitchNextState(nextState);
                }
            }
        }

        private void SwitchNextState(State state)
        {
            currentState = state;
        }

        private void HandleRecoveryTimer()
        {
            if(currentRecoveryTime > 0)
            {
                currentRecoveryTime -= Time.deltaTime;
            }

            if (isPerformingAction)
            {
                if(currentRecoveryTime <= 0)
                {
                    isPerformingAction = false;
                }
            }
        }
    }
}
