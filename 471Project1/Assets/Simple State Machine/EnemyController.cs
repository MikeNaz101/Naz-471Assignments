using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum State
    {
        Pace,
        Follow,
    }

    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    private State currentState = State.Pace;
    float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Pace:
            OnPace();
                break;
            case State.Follow:
            OnFollow();
                break;
        }
    }

    void OnPace()
    {
        print("I'm Pacing!");
        target = route[routeIndex];

        MoveTo(target);
        
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            routeIndex+=1;
            if (routeIndex >= route.Length)
            {
                routeIndex = 0;
            }
        }
        GameObject obstacle = CheckForward();
        if (obstacle != null)
        {
            target = obstacle;
            currentState = State.Follow;
        }
    }

    void OnFollow()
    {
        print("I'm Following!");
        MoveTo(target);

        GameObject obstacle = CheckForward();
        if (obstacle == null)
        {
            currentState = State.Pace;
        }
    }

    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }

    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            FirstPersonController player = hit.transform.gameObject.GetComponent<FirstPersonController>();

            if (player != null)
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }
        }
        return null;
    }
}
