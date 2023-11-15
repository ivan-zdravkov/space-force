using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfScreenCollider : MonoBehaviour
{
    private HealthDisplay healthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        this.healthDisplay = FindObjectOfType<HealthDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker attacker = collider.gameObject.GetComponent<Attacker>();
        Projectile projectile = collider.gameObject.GetComponent<Projectile>();

        if (attacker)
        {
            this.healthDisplay.RemoveHealth(attacker.Damage);

            Destroy(attacker.gameObject);
        }

        if (projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}
