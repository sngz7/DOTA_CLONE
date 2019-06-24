using System.Collections;
using UnityEngine;

//To make sure PlayerController and Player are attached to the same object
[RequireComponent (typeof (PlayerController))]
//To make sure GunController and Player are attached to the same object
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;
    void Start()
    {
        controller = GetComponent<PlayerController> ();
        viewCamera = Camera.main;
        gunController = GetComponent<GunController> ();
    }

    void Update()
    {
        // Movement Input
        // To remove auto smoothness we use raw
        Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // Look Input
        // To Point the player towards the mouse position using a ray from camera
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;


        //Holds True when ray intersects with plane
        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        //Weapon Input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
