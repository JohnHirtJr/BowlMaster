using UnityEngine;

public class Pin : MonoBehaviour
{
    //public float standingThreshold;
    private Quaternion quat;
    private new AudioSource audio;

	void Start ()
	{
        audio = gameObject.GetComponent<AudioSource>();
        quat = transform.rotation;
	}

    public void IsStanding() {

        if (transform.eulerAngles.x < 10f) {
            transform.parent = null;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.rotation = quat;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Ball")
            audio.PlayOneShot(audio.clip);
    }
}
