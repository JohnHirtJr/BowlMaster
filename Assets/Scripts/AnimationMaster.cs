using UnityEngine;
using System.Collections;

public class AnimationMaster : MonoBehaviour
{
    public Ball ball;
    public StandingChecker checker;
    public Playbox playBox;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void BallReset() {
        ball.ResetBall();
    }

    public void CheckerReset()
    {
        checker.CheckerReset();
    }

    public void GetPinCount() {
        checker.CurrentPinCount();
    }

    public void Tidy() {
        print("Tidy");
    }

    public void ResetBall() {
        print("Reset");
    }

    public void ResetPins() {
        playBox.ResetPins();
    }

    public void ActionSelect(int pinsKnockedDown) {
        switch (ActionMaster.Bowl(pinsKnockedDown)) {

            case ActionMaster.Action.Tidy:
                print("Tidy case selected.");
                anim.SetTrigger("Tidy");
                break;

            case ActionMaster.Action.Reset:
                print("Reset case selected.");
                break;

            case ActionMaster.Action.EndTurn:
                print("EndTurn case selected.");
                checker.CheckerReset();
                anim.SetTrigger("EndTurn");
                checker.UpDateCurrentPinsOnEndTurn();
                break;

            case ActionMaster.Action.EndGame:
                print("EndGame case selected.");
                break;

            default:
                print("Action not found.");
                break;
        }
    }


}
