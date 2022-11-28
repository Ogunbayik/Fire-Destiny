using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<IDamageble>();

        if (enemy != null)
        {
            enemy.CollisionPlayer();
        }
    }
}
