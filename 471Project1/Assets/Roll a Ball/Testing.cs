using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject cube;
    Transform t;
    float rotation = 0;
    float speed = .1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube.GetComponent<Transform>();
        //print("Hello Cruel World!!!");
    }

    // Update is called once per frame
    void Update()
    {
        // if(transform.position.y > 10)
        if (transform.position.y < -10)
        {
            t.transform.position = new Vector3(0f,50f,0f);
            //t.Translate(speed, 0, 0);
        }
        /*else if (t.position.y < -10)
        {
            speed = speed * -1;
            
        }
        t.Translate(0, speed, 0);
        */
        
    }
}
