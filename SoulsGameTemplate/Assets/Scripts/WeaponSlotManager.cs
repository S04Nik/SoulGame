using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkSoul
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        private void Awake()
        {
            WeaponHolderSlot[]weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }
        public void LoadWeaponOnSlot(WeaponItem item , bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(item);
            }
            else
            {
                rightHandSlot.LoadWeaponModel(item);
            }
        }
    }
}

