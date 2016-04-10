using UnityEngine;
using System.Collections;

public class SoundTriggerFilter : MonoBehaviour {

    public bool isFilterValue;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            AmbianceMusic ambianceMusicComponent = col.gameObject.GetComponent<AmbianceMusic>();
            if (ambianceMusicComponent)
                ambianceMusicComponent.isFilter = isFilterValue;
        }
    }




}
