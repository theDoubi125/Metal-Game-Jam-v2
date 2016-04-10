using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Wires : MonoBehaviour {

    public Image[] wireStates;
    private int currentState = 0;

	void Start ()
    {

    }

    public void CutFirst()
    {
        CutWire(1);
        print("CUR FIRST");
    }

    public void CutSecond()
    {
        print("CUT SECOND");
        CutWire(2);
    }

    void CutWire(int wire)
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().currentWeapon != EnumWeapons.WeaponId.Pince)
            return;
        currentState += wire;
        foreach (Image i in wireStates)
        {
            i.gameObject.SetActive(false);
        }
        wireStates[currentState].gameObject.SetActive(true);
    }
}
