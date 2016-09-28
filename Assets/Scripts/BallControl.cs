using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class BallControl : MonoBehaviour
{

    private Ball ball, ballNudge;
    private float time;
    private Vector3 velocity;
    private float mousex;
    private float mousey;
    // Use this for initialization
    void Start ()
    {
        ball = GetComponent<Ball>();
        ballNudge = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void DragStart()
    {
        time = Time.time;
        mousex = Input.mousePosition.x;
        mousey = Input.mousePosition.y;
    }

    public void DragStop() {
        time = time - Time.time;
        float distancex = mousex - Input.mousePosition.x;
        float distancey = mousey - Input.mousePosition.y;
        velocity = new Vector3(distancex, 0f, distancey) / time;
        if (Mathf.Abs(distancex) > 20f) {
            var xSign = Mathf.Sign(distancex);
            distancex = 20f*xSign;
        }
        if (Mathf.Abs(distancey) > 1300f)
        {
            var ySign = Mathf.Sign(distancey);
            distancey = 1300f*ySign;
        }
        velocity = new Vector3(-distancex, -distancey/2, -distancey*2.3f);
        ball.Launch(velocity);
    }

    public void NudgeLeft()
    {
        ballNudge.transform.position -= new Vector3(5f,0f,0f);
    }

    public void NudgeRight() {
        ballNudge.transform.position += new Vector3(5f, 0f, 0f);
    }
}
