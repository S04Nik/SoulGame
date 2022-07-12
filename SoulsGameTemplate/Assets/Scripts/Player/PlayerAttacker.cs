using UnityEngine;

namespace DarkSoul
{
    public class PlayerAttacker : MonoBehaviour
    {
        PlayerAnimatorManager animatorHandler;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;

        public string lastAttack;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
            inputHandler = GetComponent<InputHandler>();
        }

        public void HandleWeaponCombo(WeaponItem item)
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);

                if (lastAttack == item.on_light_attack_1)
                {
                    animatorHandler.PlayTargetAnimation(item.on_light_attack_2, true);
                }
                else if (lastAttack == item.th_light_attack_1)
                {
                    animatorHandler.PlayTargetAnimation(item.th_light_attack_2, true);
                }
            }
        }

        public void HandleLightAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;

            if (inputHandler.twoHandFlag)
            {
                animatorHandler.PlayTargetAnimation(weapon.th_light_attack_1, true);
                lastAttack = weapon.th_light_attack_1;
            }
            else
            {

                animatorHandler.PlayTargetAnimation(weapon.on_light_attack_1, true);
                lastAttack = weapon.on_light_attack_1;
            }
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            weaponSlotManager.attackingWeapon = weapon;

            if (inputHandler.twoHandFlag)
            {

            }
            else
            {
                animatorHandler.PlayTargetAnimation(weapon.on_heavy_attack_1, true);
                lastAttack = weapon.on_heavy_attack_1;
            }
        }
    }
}
