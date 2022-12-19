using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] Vector3 spawnRandomness;

    [SerializeField, Range(0.1f, 3f)] float minSpawnRate;
    [SerializeField, Range(0.1f, 3f)] float maxSpawnRate;

    [SerializeField] AnimationCurve difficultyCurve;
    
    [SerializeField] List<GameObject> targets;

    private List<HittableTarget> hittableTargets;

    private void Awake()
    {
        instance = this;

        hittableTargets = new List<HittableTarget>();
    }

    public void UnlistSpawnedTarget(HittableTarget target)
    {
        hittableTargets.Remove(target);
        if(hittableTargets.Count == 0)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Instantiate(hittableTargets[0], RandomVector3(), Quaternion.identity);
    }
    Vector3 RandomVector3()
    {
        return new Vector3( Random.Range(-spawnRandomness.x, spawnRandomness.x), 
                            Random.Range(-spawnRandomness.y, spawnRandomness.y), 
                            Random.Range(-spawnRandomness.z, spawnRandomness.z));
    }
}
