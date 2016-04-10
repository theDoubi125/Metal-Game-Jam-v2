using UnityEngine;
using System.Collections;

public class CrowdSpawner : MonoBehaviour {
    public Transform crowdPrefab;
    public int spawnCount;
    public float w, h;
    
	void Start () {
        for (int i = 0; i < spawnCount; i++)
            Instantiate<Transform>(crowdPrefab).position = transform.position + new Vector3(Random.value * w - w / 2, Random.value * h - h / 2);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
