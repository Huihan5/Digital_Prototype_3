using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassScript : MonoBehaviour
{
    public GameObject dream;
    public GameObject myDream;

    public bool dreaming = false;

    public float dreamGenerateTime = 5f;
    public float dreamCurrentTime = 0;

    public float wake = 0;
    public bool finished = false;

    public float loadingTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dreamCurrentTime >= dreamGenerateTime)
        {
            myDream = Instantiate(dream, transform.position + new Vector3(3, 3, 0), Quaternion.identity);
            dreamCurrentTime = 0;
            dreaming = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && myDream)
        {
            Destroy(myDream);
            wake++;
            dreaming = false;
        }

        if (!dreaming)
        {
            dreamCurrentTime += Time.deltaTime;
        }

        if(wake >= 3)
        {
            finished = true;
        }

        if (finished)
        {
            loadingTime -= Time.deltaTime;
        }

        if(loadingTime <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
