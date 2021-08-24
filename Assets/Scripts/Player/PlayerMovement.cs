using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    private float maxSpeed;
    [SerializeField, Range(0f, 100f)]
    private float maxAcceleration;
    private Camera mainCamera;
    private Vector3 velocity;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        MovePlayer();
        LookAtMouse();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 desiredVelocity = new Vector3(horizontal, 0f, vertical) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;
    }

    private void LookAtMouse()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane p = new Plane(Vector3.up, transform.position);
        if (p.Raycast(mouseRay, out float hitDist))
        {
            Vector3 hitPoint = mouseRay.GetPoint(hitDist);
            transform.LookAt(hitPoint);
        }
    }
}
