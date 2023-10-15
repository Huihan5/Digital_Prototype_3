using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float leftBoundary = -10f;
    public float rightBoundary = 10f;
    public float bottomBoundary = -5f;
    public float upBoundary = 5f;

    public int moveSpeed = 3;

    SpriteRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement & Boundary
        if (transform.position.x >= leftBoundary && transform.position.x <= rightBoundary)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = true;
            }
        }

        if (transform.position.y >= bottomBoundary && transform.position.y <= upBoundary)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                myRend.flipY = false;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                myRend.flipY = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "School")
        {
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.name == "Home")
        {
            SceneManager.LoadScene(3);
        }

        if (collision.gameObject.name == "Lake")
        {
            SceneManager.LoadScene(4);
        }
    }
}
