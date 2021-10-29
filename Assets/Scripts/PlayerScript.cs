using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    private bool isShrunk;
    public bool hasShrink;
    private int shrinkCounter;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        bool shoot = Input.GetButtonDown("Fire1");

        if (shoot)
        {
            WeaponScript weapon = GetComponentInChildren<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
        
        bool shrink = Input.GetButtonDown("Shrink");
        if (shrink) Shrink();
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
        ).y;

        var size = GetComponent<BoxCollider2D>().bounds.size;

        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, leftBorder+size.x/2, rightBorder-size.x/2),
        Mathf.Clamp(transform.position.y, topBorder+size.y/2, bottomBorder-size.y/2),
        transform.position.z
        );
    }
    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        rigidbodyComponent.velocity = movement;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp, false);
            damagePlayer = true;
        }
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1, false);
        }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShrinkScript shrinker = otherCollider.gameObject.GetComponent<ShrinkScript>();
        if (shrinker != null)
        {
            PickupShrink();
            Destroy(otherCollider.gameObject);
        }
    }
    void PickupShrink() {
        hasShrink = true;
    }
    void Shrink() {
        if (!hasShrink) return;
        hasShrink = false;
        shrinkCounter++;
        if (!isShrunk)
            transform.localScale = transform.localScale/2;
        isShrunk = true;
        Invoke("Unshrink", 5);
    }
    void Unshrink()
    {
        shrinkCounter--;
        if (shrinkCounter <= 0) {
            isShrunk = false;
            shrinkCounter = 0;
            transform.localScale = transform.localScale*2;
        }
    }
}
