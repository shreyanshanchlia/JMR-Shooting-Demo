using UnityEngine;

public class HittableTarget : MonoBehaviour
{
    public int targetID;
    [SerializeField] int score;
    [SerializeField] float lifeTime;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            ScoreManager.instance.AddScore(score);
        }
    }

    private void OnDestroy()
    {
        SpawnManager.instance.UnlistSpawnedTarget(this);
    }
}
