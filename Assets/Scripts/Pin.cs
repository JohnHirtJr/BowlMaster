using UnityEngine;

public class Pin : MonoBehaviour
{
    //public float standingThreshold;
    public Quaternion quat;
    private new AudioSource audio;

	void Start ()
	{
        audio = gameObject.GetComponent<AudioSource>();
        quat = transform.rotation;
	}

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Ball")
            audio.PlayOneShot(audio.clip);
    }
}
