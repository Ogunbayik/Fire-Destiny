using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour , IDamageble
{
    public static event Action<int> OnTriggerEnemy;

    [SerializeField]
    private int gainScore;

    private int point;

    private float movementSpeed;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementSpeed = 1f;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var offsetPosition = new Vector3(0, -1f, 0);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offsetPosition, movementSpeed * Time.deltaTime);
    }

    public void CollisionBullet()
    {
        OnTriggerEnemy?.Invoke(point);

        Destroy(gameObject);
    }

    public void CollisionPlayer()
    {
        Debug.Log("Game is Over");

        Destroy(gameObject);
    }
}
