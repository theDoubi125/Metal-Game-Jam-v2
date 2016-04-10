using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject toTrack;
	void Start ()
    {
        transform.position = toTrack.transform.position;
	}
	
	void Update ()
    {
        transform.position = (Vector3)((Vector2)(toTrack.transform.position))+new Vector3(0, 0, -1);

    }
}
