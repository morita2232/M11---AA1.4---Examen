using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public Transform targetVisual;
    public Transform targetEnemy;
    private void Update()
    {
        targetVisual.position = new Vector3(targetEnemy.position.x, 0, targetEnemy.position.z);
    }
}
