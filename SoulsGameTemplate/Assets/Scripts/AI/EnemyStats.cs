using UnityEngine;

namespace DarkSoul
{
    public class EnemyStats : CharacterStats
    {
        //public HealthBar healthBar;

        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            //healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            return healthLevel * 10;
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            //healthBar.SetCurrentHealth(currentHealth);

            animator.Play("Damage_Small");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead_01");
                // handle Death here
            }
        }
    }
}