using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField]
    private float lifeDuration = 10f;

    private float lifeTimer = 0;
    private void Start()
    {
        lifeTimer = lifeDuration;
    }
    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
