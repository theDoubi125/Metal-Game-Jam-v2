using UnityEngine;
using System.Collections;

public class EnumWeapons : MonoBehaviour {

    public enum WeaponId : int { NO_WEAPON, Marteau, Pince, Perceuse, Biere, Tournevis}
    public enum WeaponType : int { HAMMER, SCREWDRIVER, LIQUID };

}
