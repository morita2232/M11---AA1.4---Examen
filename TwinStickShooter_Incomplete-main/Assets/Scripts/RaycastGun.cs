using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LineRenderer line;
    public float lineFadeSpeed;
    public LayerMask mask;
    public LayerMask Cubemask;
    public float knockbackForce = 10;
    public EnemyController enemy;
    RaycastHit hit;
    void Update()
    {
        line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, line.startColor.a - Time.deltaTime * lineFadeSpeed);
        line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, line.endColor.a - Time.deltaTime * lineFadeSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, 1);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, 1);

            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 1000);

            if (Physics.Raycast(line.GetPosition(0), transform.forward * 1000, out hit, line.GetPosition(1).x, mask))
            {
                Rigidbody rb = hit.rigidbody;
                if (rb != null)
                {
                    enemy.Kill();
                }
            }
            if (Physics.Raycast(line.GetPosition(0), transform.forward * 1000, out hit, line.GetPosition(1).x, Cubemask))
            {
                Rigidbody rb = hit.rigidbody;
                if (rb != null)
                {
                    rb.AddForceAtPosition(line.transform.forward * knockbackForce, hit.transform.position);
                }
            }
        }
    }
}
