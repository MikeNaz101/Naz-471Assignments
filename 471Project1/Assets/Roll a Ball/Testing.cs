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
        if(t.position.y > 10)
        {
            speed = speed * -1;
            //t.Translate(speed, 0, 0);
        }
        else if (t.position.y < -10)
        {
            speed = speed * -1;
            
        }
        t.Translate(0, speed, 0);
        
        //rotation = rotation + 0.001f;
        //t.Rotate(rotation,0,0);


        
        /*if(score <= 100)
        {
            score++;
            if(score%10 == 0)
            {
                print(score);
            }
        }
        else if (score >= 100)
        {
            print("You Win!!!");
            Destroy(cube);
        }*/
    }
}
