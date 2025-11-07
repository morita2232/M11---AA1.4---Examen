using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrenadeController : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask mask;
    public float launchForce;
    public float timer;
    public float radius;
    public float explosionForce;
    public GameObject particles;
    public EnemyController enemy;
    
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        //Aplicar fuerza de impulso en la direccion "up" del transform
        rb.AddForce(transform.up * launchForce, ForceMode.Impulse);

        StartCoroutine(explotion());
        
    }

    IEnumerator explotion()
    {
       yield return new WaitForSeconds(3);
        Instantiate(particles, transform.position, transform.rotation);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            Rigidbody rb = enemy.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * explosionForce, ForceMode.Force);
            enemy.Kill();
            
        }
        Destroy(gameObject);
    }
}
