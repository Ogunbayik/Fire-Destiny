using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour , IDamageble
{
    public static event Action<int> OnTriggerEnemy;

    private GameObject player;
    private int value;
    private float movementSpeed;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
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

        Vector3 lookDirection = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        transform.LookAt(lookDirection);
    }


    public void CollisionBullet()
    {
        OnTriggerEnemy?.Invoke(value);
        GameManager.Instance.enemyList.Remove(this.gameObject);
        Destroy(gameObject);
    }

    public void CollisionPlayer()
    {
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }
}
