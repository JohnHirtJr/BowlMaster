using UnityEngine;
using UnityEngine.Networking;

public class Ball : MonoBehaviour
{
    private Rigidbody ball;
    private AudioSource ballRollingAudio;
    private float force = 0;
    private Vector3 startPos;
	// Use this for initialization
	void Start ()
	{
	    startPos = transform.position;
        Debug.Log(startPos+": ball's starting position.");
	    ball = GetComponent<Rigidbody>();
	    ball.useGravity = false;
	    ballRollingAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

    }
    void FixedUpdate() {
        ball.AddForce(force,0,0f, ForceMode.Acceleration);

    }

    public void Launch(Vector3 velocity)
    {
        ball.isKinematic = false;
        ball.useGravity = true;
        ball.velocity = velocity;
        ball.angularVelocity = new Vector3(0f,-7f,0f);
        ball.rotation = Quaternion.Euler(0f, 30f, 0f);
        force = -velocity.x;
            //new Vector3(Random.Range(-30f, 30f), 0f, velocity);
        ball.useGravity = true;
        print(velocity);
    }

    void OnCollisionEnter(Collision coll) {
        ballRollingAudio.Play();

    }

    public void ResetBall()
    {
        ball.useGravity = false;
        ball.angularVelocity = Vector3.zero;
        ball.velocity = Vector3.zero;
        ball.isKinematic = true;
        transform.position = startPos;
        Debug.Log("ResetBall called, new position: "+transform.position);
    }


}
