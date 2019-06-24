using System.Collections;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    float speed = 10;
    public float damage;

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
       
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        hit.collider.gameObject.GetComponent<EnemyKilling>().health -= damage;
        print(hit.collider.gameObject.name);
        Destroy(this.gameObject);
    }
  
} 
