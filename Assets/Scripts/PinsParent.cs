using UnityEngine;
using UnityEngine.UI;

public class PinsParent : MonoBehaviour
{
    private GameObject pinsLeftText;
    private Text text;
    private Pin[] pins;

    void Start () {

        pinsLeftText = GameObject.Find("PinsLeft");
        text = pinsLeftText.GetComponent<Text>();
    }

    void IsStanding() {
        pins = GetComponentsInChildren<Pin>();
        foreach (Pin pin in pins) {
            pin.IsStanding();
        }
    }

    public void CurrentPinCount() {

        int pinsleft = transform.childCount;
        text.text = pinsleft.ToString();
    }

    public void ReParent()
    {
        pins = FindObjectsOfType<Pin>();
        foreach (Pin pin in pins)
        {
            pin.transform.parent = transform;
            pin.GetComponent<Rigidbody>().isKinematic = false;
        }

        CurrentPinCount();
    }

}
