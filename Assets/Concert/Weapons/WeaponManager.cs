using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

    public EnumWeapons.WeaponId currentWeapon;


    public void setWeapon(EnumWeapons.WeaponId newWeapon)
    {
        currentWeapon = newWeapon;
        GameObject[] guiWeapons = GameObject.FindGameObjectsWithTag("GUIWeapons");
        if (guiWeapons != null && guiWeapons.Length > 0)
        {
            Sprite sprite = (Sprite)Resources.Load("Weapons/arme" + (int)currentWeapon, typeof(Sprite));
            print("Sprite");
            ToolCursor.instance.SelectTool(sprite);
            guiWeapons[0].GetComponent<Image>().sprite = sprite;
            print("done");
        }
    }

}
