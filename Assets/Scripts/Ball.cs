using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public Rigidbody2D body;

    public UnityEvent onGameOver;

    public float verticalSpeed = 1.5f;
    public float horizontalSpeed = 1f;
    short verticalDirection = 1;
    short horizontalDirection = 1;
    bool isReady;

    #region unity cicle

    void Start()
    {
        isReady = false;
        horizontalDirection = 0;
        verticalDirection = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            body.velocity = new Vector2(horizontalSpeed * horizontalDirection, verticalSpeed * verticalDirection);
            if (transform.position.y < -2f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                isReady = true;
                verticalDirection = 1;
                if (Input.GetAxis("Horizontal") > 0)
                {
                    horizontalDirection = 1;
                }
                else
                {
                    horizontalDirection = -1;
                }
            }
        }
    }
    #endregion

    #region colisao
    void OnCollisionEnter2D(Collision2D other)
    {
        //bater nos limites do jogo
        if (other.gameObject.tag == "Limit")
        {
            horizontalDirection *= -1;
        }
        if (other.gameObject.tag == "LimitSuperior")
        {
            verticalDirection *= -1;
        }
        //bater no player
        if (other.gameObject.tag == "Player")
        {
            verticalDirection *= -1;
            verticalSpeed += 0.1f;
            horizontalSpeed += 0.1f;
        }
        //bater nos blocos
        if (other.gameObject.tag == "L")
        {
            horizontalDirection *= -1;
            other.gameObject.transform.parent.gameObject.GetComponent<Block>().Remove();
        }
        if (other.gameObject.tag == "S")
        {
            verticalDirection *= -1;
            other.gameObject.transform.parent.gameObject.GetComponent<Block>().Remove();
        }

        Debug.Log($"bateu no objeto de nome {other.gameObject.tag}");
    }
    #endregion
}
