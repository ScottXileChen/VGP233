using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lifeDuration = 10f;
    [SerializeField]
    private float damageMin = 5;
    [SerializeField]
    private float damageMax = 10;

    private float lifeTimer = 0;
    private void Start()
    {
        lifeTimer = lifeDuration;
    }
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage = (int)Random.Range(damageMin, damageMax);
        if (other.gameObject.layer.Equals(9))
        {
            Destroy(other.gameObject);
        }
    }
}
