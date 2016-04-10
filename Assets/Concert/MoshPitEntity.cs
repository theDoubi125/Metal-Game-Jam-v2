using UnityEngine;
using System.Collections;

public class MoshPitEntity : MonoBehaviour
{
    public float pushStrength, circlePitSpeed, circlePitCloseSpeed;
    private MoshPitBehaviour currentBehaviour;
    MoshPitSpawner spawner;
    CirclePitBehaviour circlePitBehaviour;
    PogoBehaviour pogoBehaviour;

    void Start ()
    {

    }

    void Update()
    {
    }

    public void Init(MoshPitSpawner spawner)
    {
        this.spawner = spawner;
        circlePitBehaviour = GetComponent<CirclePitBehaviour>();
        pogoBehaviour = GetComponent<PogoBehaviour>();
        circlePitBehaviour.Init(spawner, spawner.transform.position, spawner.radius, circlePitCloseSpeed, circlePitSpeed);
        pogoBehaviour.Init(spawner, spawner.transform.position, spawner.radius, pushStrength, 1, 2);
        StartPogo();
    }

    public void StartCirclePit()
    {
        circlePitBehaviour.enabled = true;
        pogoBehaviour.enabled = false;
    }

    public void StartPogo()
    {
        circlePitBehaviour.enabled = false;
        pogoBehaviour.enabled = true;
    }
}
