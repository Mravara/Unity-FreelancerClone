using UnityEngine;

public class TestBullet : AbstractBullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
            return;
        else
        {
            Debug.Log("Boom");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
