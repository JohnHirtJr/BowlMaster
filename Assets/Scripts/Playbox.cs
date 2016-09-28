using UnityEngine;

public class Playbox : MonoBehaviour
{
    private StandingChecker standingChecker;

    void Start()
    {
        standingChecker = FindObjectOfType<StandingChecker>();
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
