using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject firePoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float movementSpeed;

    private Vector3 desiredDirection;
    void Start()
    {
        firePoint = GameObject.Find("FirePoint");
        player = GameObject.FindGameObjectWithTag("Player");

        desiredDirection = (firePoint.transform.position - player.transform.position);
    }

    void Update()
    {
        transform.position += desiredDirection * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<IDamageble>();

        if (enemy != null)
        {
            enemy.CollisionBullet();
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
