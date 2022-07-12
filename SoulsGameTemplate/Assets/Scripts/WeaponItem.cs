using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkSoul
{
    [CreateAssetMenu(menuName ="Item/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Idle Animations")]
        public string right_hand_idle;
        public string left_hand_idle;
        public string th_idle; // 2hand

        [Header("Attack Animations")]
        public string on_light_attack_1;
        public string on_light_attack_2;
        public string on_heavy_attack_1;
        public string on_heavy_attack_2;
        public string th_light_attack_1;
        public string th_light_attack_2;


        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;


    }
}

