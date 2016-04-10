using UnityEngine;
using System.Collections;

public class CirclePitBehaviour : MoshPitBehaviour
{
    public float targetRadius, getCloserStrength, circleStrength, pushStrength, pushMinDelay, pushMaxDelay;
    private Vector2 target;
    private float time;
    private Rigidbody2D body;
    private MoshPitSpawner spawner;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Init(MoshPitSpawner spawner, Vector2 target, float targetRadius, float getCloserStrength, float circleStrength)
    {
        this.target = target;
        this.targetRadius = targetRadius;
        this.spawner = spawner;
        this.getCloserStrength = getCloserStrength;
        this.circleStrength = circleStrength;
    }

    void FixedUpdate()
    {
        if (!GameState.instance.isRunning())
            return;
        Vector2 pushDir = (Vector2)Vector3.Cross(((Vector3)target - transform.position), new Vector3(0, 0, 1));
        Vector2 getCloserDir = target - (Vector2)transform.position;
        body.AddForce(pushDir.normalized * circleStrength);

        body.AddForce(getCloserDir.normalized * getCloserStrength * (getCloserDir.sqrMagnitude < targetRadius * targetRadius ? -1 : 1));

        /*time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            Push();
        }*/
    }

    private void ResetDelay()
    {
        time = pushMinDelay + Random.value * (pushMaxDelay - pushMinDelay);
    }

    private void Push()
    {
        Vector2 pushDir = (Vector2)Vector3.Cross(((Vector3)target - transform.position), new Vector3(0, 0, 1));
        //Vector2 pushtarget = target + Random.insideUnitCircle * targetRadius;
        body.AddForce(pushDir.normalized * getCloserStrength / Time.fixedDeltaTime);
        ResetDelay();
    }
}
