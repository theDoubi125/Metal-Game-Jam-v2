using UnityEngine;
using System.Collections;

public class MoshPitSpawner : MonoBehaviour
{
    public Transform entityPrefab;

    public float circlePitRatio = 0.3f;
    public int entityCount;
    public float radius;
    public float wodMinDelay, wodMaxDelay;

    public float time;

    MoshPitEntity[] entities;

    private Vector2 m_massCenter;

    public Vector2 massCenter { get { return m_massCenter; } }

    public enum pitState { Pogo, CirclePit, WallofDeath };
    private pitState currentPitState;

	void Start ()
    {
        entities = new MoshPitEntity[entityCount];
	    for(int i=0; i < entityCount; i++)
        {
            Transform entityTransform = (Transform)Instantiate<Transform>(entityPrefab);
            entities[i] = entityTransform.GetComponent<MoshPitEntity>();
            entities[i].Init(this);
            entities[i].transform.position = Random.insideUnitCircle * radius;
        }
	}
	
	void FixedUpdate ()
    {
        time -= Time.fixedDeltaTime;
        if(time < 0)
        {
            time = Random.Range(wodMinDelay, wodMaxDelay);
            if (currentPitState == pitState.Pogo)
            {
                currentPitState = pitState.CirclePit;
                foreach (var entity in entities)
                    if (Random.value > circlePitRatio)
                        entity.StartCirclePit();
            }
            else if (currentPitState == pitState.CirclePit)
            {
                currentPitState = pitState.Pogo;
                foreach (var entity in entities)
                    entity.StartPogo();
            }
        }
        m_massCenter = Vector2.zero;
        foreach(var entity in entities)
        {
            m_massCenter += (Vector2)entity.transform.position;
        }
        m_massCenter /= entities.Length;
	}
}
