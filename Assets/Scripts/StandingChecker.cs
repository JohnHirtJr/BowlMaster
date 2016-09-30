using UnityEngine;
using UnityEngine.UI;

public class StandingChecker : MonoBehaviour
{
    private GameObject pinsLeftText;
    private AnimationMaster am;
    private Text text;
    private Pin pin;
    private int lastChildCount = 10;
    // Use this for initialization
    void Start ()
    {
        am = FindObjectOfType<AnimationMaster>();
	    GetComponent<Collider>().enabled = false;
        pinsLeftText = GameObject.Find("PinsLeft");
        text = pinsLeftText.GetComponent<Text>();
        text.text = lastChildCount.ToString();
        ActionMaster.ResetList();
	}

    void OnTriggerStay(Collider coll) {
        print("Standing Checker initialized. Parenting standing pins.");
        if (coll.tag == "Pin") {
            pin = coll.gameObject.GetComponent<Pin>();
            coll.transform.parent = transform;
            coll.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            coll.transform.rotation = pin.quat;
        }
    }

    public void CheckerReset() {
        GetComponent<Collider>().enabled = false;
        Release();
    }

    public void UpDateCurrentPinsOnEndTurn() {
        lastChildCount = 10;
        text.text = lastChildCount.ToString();
    }

    void Release() {
        transform.DetachChildren();
        print("releasing");
        Pin[] pins = FindObjectsOfType<Pin>();
        foreach (Pin pin in pins) {
            pin.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void CurrentPinCount() {
        int currentChildCount = transform.childCount;
        print("Current child count: "+currentChildCount);
        int pinsKnockedDown = Mathf.Abs(lastChildCount - currentChildCount);
        print("Pins knocked down: "+pinsKnockedDown);
        //int pinsKnockedDown = pinsleft - lastChildCount;
        //print("Pins knocked down: "+pinsKnockedDown);
        text.text = pinsKnockedDown.ToString();
        lastChildCount = currentChildCount;
        print("Last child count: "+lastChildCount);
        print("Updating pin count and choosing next action.");
        am.ActionSelect(pinsKnockedDown);
    }

}
