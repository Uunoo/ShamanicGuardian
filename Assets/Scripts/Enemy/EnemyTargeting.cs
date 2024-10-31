using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public Transform targetPlayer;
    public float rotateSpeed;

    void Update()
    {
        if (!targetPlayer)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            targetPlayer = (GameObject.FindGameObjectWithTag("Player").transform);
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetPlayerDirection = targetPlayer.position - transform.position;
        float angle = Mathf.Atan2(targetPlayerDirection.y, targetPlayerDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }


}
