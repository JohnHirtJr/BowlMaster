using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class ActionMaster : MonoBehaviour
{

    public enum Action {Tidy,EndTurn,Reset,EndGame};

    //private int pinsKnockedDown;
    //private int[] frames = new int[21];
    private static List<int> scores = new List<int>();

    void Start() {
        foreach (var score in scores)
        {
            Debug.Log(score);
        }
        Debug.Log(scores.Count);
        //Debug.Log(scores[3]+scores[1]);
    }

    public static Action Bowl(int pinsKnockedDown)
    {
        scores.Add(pinsKnockedDown);

        // last frame
        if (scores.Count == 19){
            if (pinsKnockedDown == 10)
            {
                return Action.Reset;
            }
            return Action.Tidy;
        }

        if (scores.Count == 20)
        {
            if (pinsKnockedDown == 10)
                return Action.Reset;
            if(scores[18] == 10)
                return Action.Tidy;
            if (ThirdBowlAwarded())
                return Action.Reset;
            return Action.EndGame;
        }

        if (scores.Count == 20 && !ThirdBowlAwarded())
            return Action.EndGame;

        if (scores.Count == 21)
            return Action.EndGame;

        if (scores.Count % 2 == 0) {
            if (pinsKnockedDown == 10) {   //this might not need to be in here
                return Action.EndTurn;
            }
            if (pinsKnockedDown < 10 || pinsKnockedDown >= 0) {
                return Action.EndTurn;
            }
            return Action.Tidy;
        }

        if (pinsKnockedDown == 10) {
            scores.Add(-1);
            return Action.EndTurn;
        }

        if (pinsKnockedDown <= 10 || pinsKnockedDown >= 0) {
            return Action.Tidy;
        }

        if (pinsKnockedDown > 10 || pinsKnockedDown < 0)
            throw new UnityException("Pins knocked down out of range!");

        throw new UnityException("Not sure which action to return!");
    }

    public static void ResetList() {
        scores = new List<int>();
    }

    static bool ThirdBowlAwarded() {
        if (scores[19 - 1] + scores[20 - 1] == 10) {
            return true;
        }
        return false;
    }
}
