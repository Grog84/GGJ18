using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRay : MonoBehaviour
{
    public float speed;
    public float verticalSpeed;
    public Transform player;

    public Vector3 offset;
    public LayerMask layerMask;

    public bool hasReachedGround;
    public bool hasReachedTop;
    public bool hasHitWallR;
    public bool hasHitWallL;

    public bool hasCollided;

    public bool chargeReady = true;
    public float maxCharge = 4f;

    public float feetRaycastLength = 1f;
    public float headtRaycastLength = 1f;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        Move();
        UpdatePlayerPosition();
        CheckGround();
        CheckWalls();
    }

    private void Move()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (hasHitWallR)
        {
            horInput = Mathf.Min(horInput, 0);
        }
        if (hasHitWallL)
        {
            horInput = Mathf.Max(0, horInput);
        }

        if (Input.GetAxis("Jump") > 0 && chargeReady)
        {
            transform.position = new Vector3(transform.position.x + speed * horInput * Time.deltaTime, transform.position.y + verticalSpeed * Time.deltaTime, transform.position.z);


            maxCharge -= Time.deltaTime;
            if (maxCharge <= 0)
            {
                chargeReady = false;
                StartCoroutine(RechargeCO());
            }
        }
        else if (!hasReachedGround)
        {
            transform.position = new Vector3(transform.position.x + speed * horInput * Time.deltaTime, transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
        }
        
        else
            transform.position = new Vector3(transform.position.x + speed * horInput * Time.deltaTime, transform.position.y, transform.position.z);
    }

    IEnumerator RechargeCO()
    {
        while (maxCharge < 4)
        {
            maxCharge += Time.fixedDeltaTime;
            yield return null;
        }
        maxCharge = 4f;
        chargeReady = true;
        yield return null;
    }

    private void CheckGround()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        Debug.DrawLine(position, position + Vector2.down * feetRaycastLength, Color.red);
        Debug.DrawLine(position + Vector2.right * 0.5f, position + Vector2.right * 0.5f + Vector2.down * feetRaycastLength, Color.red);
        Debug.DrawLine(position + Vector2.left * 0.5f, position + Vector2.left * 0.5f + Vector2.down * feetRaycastLength, Color.red);

        hasReachedGround = Physics2D.Raycast(position, Vector2.down, feetRaycastLength, layerMask) || 
            Physics2D.Raycast(position + Vector2.right * 0.5f, Vector2.down, feetRaycastLength, layerMask) || 
            Physics2D.Raycast(position + Vector2.left * 0.5f, Vector2.down, feetRaycastLength, layerMask);
        
        hasReachedTop = Physics2D.Raycast(position, Vector2.up, headtRaycastLength, layerMask);
    }

    private void CheckWalls()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        Debug.DrawLine(position, position + Vector2.right * feetRaycastLength, Color.red);
        Debug.DrawLine(position + Vector2.up * 0.5f, position + Vector2.up * 0.5f + Vector2.right * feetRaycastLength, Color.red);
        Debug.DrawLine(position + Vector2.down * 0.5f, position + Vector2.down * 0.5f + Vector2.right * feetRaycastLength, Color.red);

        Debug.DrawLine(position, position + Vector2.left * feetRaycastLength, Color.red);
        Debug.DrawLine(position + Vector2.up * 0.5f, position + Vector2.up * 0.5f + Vector2.left * feetRaycastLength, Color.red);
        Debug.DrawLine(position + Vector2.down * 0.5f, position + Vector2.down * 0.5f + Vector2.left * feetRaycastLength, Color.red);

        hasHitWallR = Physics2D.Raycast(position, Vector2.right, feetRaycastLength, layerMask) ||
            Physics2D.Raycast(position + Vector2.up * 0.5f, Vector2.right, feetRaycastLength, layerMask) ||
            Physics2D.Raycast(position + Vector2.down * 0.5f, Vector2.right, feetRaycastLength, layerMask);


        hasHitWallL = Physics2D.Raycast(position, Vector2.left, feetRaycastLength, layerMask) ||
            Physics2D.Raycast(position + Vector2.up * 0.5f, Vector2.left, feetRaycastLength, layerMask) ||
            Physics2D.Raycast(position + Vector2.down * 0.5f, Vector2.left, feetRaycastLength, layerMask);

    }

    void UpdatePlayerPosition()
    {
        player.position = transform.position + offset;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

}
