using UnityEngine;

public class Playbox : MonoBehaviour
{
    private StandingChecker standingChecker;
    private float startTime = 10000;
    private float currentTime;
    private float endTime = 5f;
    public Pin[] newPins;
    private bool timer = false;
    private bool ballInPlay = true;

    void Start()
    {
        standingChecker = FindObjectOfType<StandingChecker>();
    }

    void Update()
    {
        currentTime = Time.time;
        if (currentTime - startTime > endTime && timer == true) {
            print("Time's up!");
            timer = false;
            EnableStandingChecker();

        }
        if (ballInPlay == false) {
            BeginTimer();
            ballInPlay = true;
        }

    }

    void OnTriggerExit(Collider coll) {

        if(coll.tag == "Pin")
            Destroy(coll.gameObject);
        if (coll.tag == "Ball" && ballInPlay == true)
            ballInPlay = false;
        Debug.Log("Ball has left play, beginning timer to enable StandingChecker.");
    }

    void EnableStandingChecker()
    {
        standingChecker.GetComponent<Collider>().enabled = true;
        Invoke("GetPinCount", 2f);
        print("Getting pin count in 2 seconds...");
    }

    public void BeginTimer()
    {
        startTime = currentTime;
        print("Timer started...");
        timer = true;
    }

    void GetPinCount() {
        print("Getting pin count.");
        standingChecker.CurrentPinCount();
    }

    public void ResetPins() {
        //foreach (Pin pin in newPins)
        //{
            for (int i = 0; i < 10; i++) {
                Instantiate(newPins[i]);
            }
        //}
    }
}
