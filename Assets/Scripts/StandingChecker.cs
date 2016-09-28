using UnityEngine;

public class StandingChecker : MonoBehaviour
{
    public GameObject pins;
    private Pin pin;
	// Use this for initialization
	void Start ()
	{
	    GetComponent<Collider>().enabled = false;
	}
	
    //disable collider via Animator
    void OnTriggerStay(Collider coll) {
        print("Standing Checker initialized. Parenting IsStanding pins.");
        if (coll.tag == "Pin") {
            pin = coll.gameObject.GetComponent<Pin>();
            coll.transform.parent = transform;
            pin.IsStanding();
        }
    }

    public void CheckerReset() {
        GetComponent<Collider>().enabled = false;
    }

    void ReParent() {
        pins.GetComponent<PinsParent>().ReParent();
    }

    void Release() {
        GetComponent<Collider>().enabled = false;
        transform.DetachChildren();
        print("releasing");
        ReParent();
    }

}
