using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float projSpeed = 1f;
    [SerializeField] float damage = 50f;
    [Header("Settings for manually setting the projectile direction")]
    [SerializeField] bool isProjDirectionOn = true;
    [SerializeField] Vector2 projDirection = Vector2.right;
    void Update()
    {
        if(isProjDirectionOn)
        {
            transform.Translate(projDirection * projSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * projSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
