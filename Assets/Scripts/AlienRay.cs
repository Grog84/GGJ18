using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRay : MonoBehaviour
{
    public float speed;
    public Transform player;

    public Vector3 offset;
    public LayerMask layerMask;

    public bool hasReachedGround;
    public bool hasReachedTop;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        Move();
        UpdatePlayerPosition();
        CheckGround();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        else if (Input.GetKey(KeyCode.W) && !hasReachedTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }

        else if (Input.GetKey(KeyCode.S) && !hasReachedGround)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
    }

    private void CheckGround()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        
        hasReachedGround = Physics2D.Raycast(position, Vector2.down, 0.9f, layerMask);
        hasReachedTop = Physics2D.Raycast(position, Vector2.up, 0.9f, layerMask);
    }

    void UpdatePlayerPosition()
    {
        player.position = transform.position + offset;
    }
}
