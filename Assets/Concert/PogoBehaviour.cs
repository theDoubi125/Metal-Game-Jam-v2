using UnityEngine;
using System.Collections;

public class PogoBehaviour : MoshPitBehaviour
{
    private float targetRadius, pushStrength, pushMinDelay, pushMaxDelay;
    private Vector2 target;
    private float time;
    private Rigidbody2D body;
    private MoshPitSpawner spawner;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Init(MoshPitSpawner spawner, Vector2 target, float targetRadius, float pushStrength, float pushMinDelay, float pushMaxDelay)
    {
        this.target = target;
        this.targetRadius = targetRadius;
        this.spawner = spawner;
        this.pushStrength = pushStrength;
        this.pushMinDelay = pushMinDelay;
        this.pushMaxDelay = pushMaxDelay;
    }

    void FixedUpdate()
    {
        Vector2 pushDir = (Vector2)Vector3.Cross(((Vector3)target - transform.position), new Vector3(0, 0, 1));
        Vector2 getCloserDir = target - (Vector2)transform.position;
        
        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            Push();
        }
    }

    private void ResetDelay()
    {
        time = pushMinDelay + Random.value * (pushMaxDelay - pushMinDelay);
    }

    private void Push()
    {
        Vector2 pushtarget = target + Random.insideUnitCircle * targetRadius;
        body.AddForce((pushtarget - (Vector2)transform.position).normalized * pushStrength / Time.fixedDeltaTime);
        ResetDelay();
    }
}
