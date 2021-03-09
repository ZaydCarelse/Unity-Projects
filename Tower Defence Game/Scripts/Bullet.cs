using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Targetting:")]
    private Transform target;

    [Header("Movement:")]
    public float speed = 70f;

    [Header("Media Objects:")]
    public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        target = _target;
    }


    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Creates particle effect at the place of impact
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        Destroy(gameObject);

    }
}
