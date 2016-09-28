using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball ball;
    private Vector3 offset;
	// Use this for initialization
	void Start ()
	{
	    offset = transform.position - ball.transform.position;
        
	}
	// Update is called once per frame
	void Update ()
	{
        if (ball.transform.position.z <= 1629f && ball.transform.position.y >= 0f)
            transform.position -= ((transform.position - ball.transform.position) - offset) * .99f * Time.deltaTime;

        else if(transform.position.z <= 1429f)
        {
            transform.position -= new Vector3(0 , -.05f ,(transform.position.z - 1629f ) * Time.deltaTime);
        }
    }
}
