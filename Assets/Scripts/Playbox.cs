using UnityEngine;

public class Playbox : MonoBehaviour
{
    private GameObject standingChecker;
    // Use this for initialization
    void Start()
    {
        standingChecker = GameObject.Find("StandingChecker");
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerExit(Collider coll) {

        if(coll.tag == "Pin")
            Destroy(coll.gameObject);
        if(coll.tag == "Ball")
            Invoke("EnableStandingChecker", 4f);
        Debug.Log("ball has left, enabling StandingChecker collider.");
    }
    void EnableStandingChecker()
    {
        standingChecker.GetComponent<Collider>().enabled = true;
    }
}
