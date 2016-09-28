using UnityEngine;
using System.Collections;

public class AnimationMaster : MonoBehaviour
{

    public Ball ball;
    public StandingChecker checker;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BallReset() {
        ball.ResetBall();
    }

    public void CheckerReset()
    {
        checker.CheckerReset();
    }
}
