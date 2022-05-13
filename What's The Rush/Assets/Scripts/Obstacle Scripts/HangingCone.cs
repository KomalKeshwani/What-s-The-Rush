using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingCone : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField]
    private LayerMask playerLayer;

    private RaycastHit2D playerHit;

    private bool playerDetected;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        DetectPlayer();
    }

    private void OnDisable()
    {
        CancelInvoke("DetectivateObject");

    }
    void DetectPlayer()
    {
        if (playerDetected)
            return;

        playerHit = Physics2D.Raycast(transform.position, Vector2.down, 100f, playerLayer);

        if (playerHit)
        {
            playerDetected = true;
            Invoke("DetectivateObject", 2f);
            myBody.gravityScale = 1f;
        }
    }

    void DetectivateObject()
    {
        gameObject.SetActive(false);
    }





}//class



















