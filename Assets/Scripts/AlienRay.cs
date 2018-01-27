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

    public bool chargeReady = true;
    public float maxCharge = 4f;

    public float feetRaycastLength = 4.5f;
    public float headtRaycastLength = 0.5f;

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

        if (Input.GetAxis("Jump") > 0 && chargeReady)
        {
            transform.position = new Vector3(transform.position.x + speed * Input.GetAxis("Horizontal") * Time.deltaTime, transform.position.y + verticalSpeed * Time.deltaTime, transform.position.z);
            maxCharge -= Time.deltaTime;
            if (maxCharge <= 0)
            {
                chargeReady = false;
                StartCoroutine(RechargeCO());
            }
        }
        else if (!hasReachedGround)
        {
            transform.position = new Vector3(transform.position.x + speed * Input.GetAxis("Horizontal") * Time.deltaTime, transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
        }
        else
            transform.position = new Vector3(transform.position.x + speed * Input.GetAxis("Horizontal") * Time.deltaTime, transform.position.y, transform.position.z);
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
        hasReachedGround = Physics2D.Raycast(position, Vector2.down, feetRaycastLength, layerMask);
        
        hasReachedTop = Physics2D.Raycast(position, Vector2.up, headtRaycastLength, layerMask);
    }

    void UpdatePlayerPosition()
    {
        player.position = transform.position + offset;
    }
}
