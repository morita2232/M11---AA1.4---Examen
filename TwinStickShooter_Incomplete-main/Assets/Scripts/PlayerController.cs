using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public Transform target;
    public Transform player;

    private InputSystem_Actions inputs;

    private void Start()
    {
        inputs = new InputSystem_Actions();
        inputs.Enable();

    }
    void Update()
    {

        player.forward = new Vector3(target.position.x * speedRotation, 0, target.position.z * speedRotation);

        Vector2 dir = inputs.Player.Move.ReadValue<Vector2>();

        transform.position +=
            Vector3.ProjectOnPlane(player.forward, Vector3.up).normalized
            * dir.y * speed * Time.fixedDeltaTime;


        transform.position +=
            Vector3.ProjectOnPlane(player.right, Vector3.up).normalized
            * dir.x * speed * Time.fixedDeltaTime;



    }
}
