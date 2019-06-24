using System.Collections;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody> ();    
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookpoint)
    {
        //For no bending while looking
        Vector3 heightCorrection = new Vector3(lookpoint.x, transform.position.y, lookpoint.z);
        transform.LookAt (heightCorrection);
    }

    public void FixedUpdate()
    {
        myRigidbody.MovePosition (myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
