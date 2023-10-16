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

    public AudioSource mySource;
    public AudioClip walkingSound;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (transform.position.x > leftBoundary && transform.position.x < rightBoundary)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = true;

                WalkingSound();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                myRend.flipX = false;

                WalkingSound();
            }
        }

        if (transform.position.y > bottomBoundary && transform.position.y < upBoundary)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                //myRend.flipY = false;

                WalkingSound();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                //myRend.flipY = true;

                WalkingSound();
            }
        }

        //Boundary
        //if (transform.position.x < leftBoundary)
        //{
        //    transform.position = new Vector3 (leftBoundary, transform.position.y, 0);

        //}
        //else if (transform.position.x > rightBoundary)
        //{
        //    transform.position = new Vector3(rightBoundary, transform.position.y, 0);
        //}

        //if (transform.position.x < bottomBoundary)
        //{
        //    transform.position = new Vector3(transform.position.x, bottomBoundary, 0);

        //}
        //else if (transform.position.x > upBoundary)
        //{
        //    transform.position = new Vector3(transform.position.x, upBoundary, 0);
        //}

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

        //if (collision.gameObject.name == "Lake")
        //{
        //    SceneManager.LoadScene(4);
        //}
    }

    void WalkingSound()
    {
        if (!mySource.isPlaying)
        {
            mySource.PlayOneShot(walkingSound);
        }
    }
}
