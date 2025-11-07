using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float stoppingDistance;
    public Transform target;
    public Transform enemy;
    public GameObject bones;
    public GameManager manager;
    Rigidbody rb;

    private void Start()
    {
         rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        enemy.forward += new Vector3(target.position.x * speedRotation, 0, target.position.z * speedRotation);





    }

    public void Kill()
    {

        Rigidbody body = GetComponent<Rigidbody>();
        body.mass = 0;
        body.useGravity = false;
        body.linearVelocity = Vector3.zero;
        Animator animator = GetComponent<Animator>();
        animator.enabled = false;
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        bones.GetComponent<Rigidbody>().mass = 1;
        manager.endEnemy++;
        EnemyController controller = GetComponent<EnemyController>();
        controller.enabled = false;


    }
}
