using UnityEngine;

public class StandingChecker : MonoBehaviour
{
    public GameObject swiper;
    public GameObject pins;
    private Pin pin;
    private Animator anim;
    private Animator swiperAnim;
	// Use this for initialization
	void Start ()
	{
	    GetComponent<Collider>().enabled = false;
	    anim = GetComponent<Animator>();
	    swiperAnim = swiper.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider coll) {
        print("i'm on now");
        if (coll.tag == "Pin") {
            pin = coll.gameObject.GetComponent<Pin>();
            coll.transform.parent = transform;
            pin.IsStanding();
        }
        if (anim.GetBool("LiftBool") == false) {
            //anim.SetBool("LiftBool", true);
            anim.SetTrigger("Lift");
        }

        if (swiperAnim.GetBool("SwipeBool") == false) {
            //swiperAnim.SetBool("SwipeBool", true);
            swiperAnim.SetTrigger("Swipe");
        }
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
