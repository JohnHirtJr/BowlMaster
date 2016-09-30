using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        ActionMaster.ResetList();
        Assert.AreEqual(endTurn, ActionMaster.Bowl(10));
    }

    [Test]
    public void T02FirstRollOfTurnLessThanTen() {
        ActionMaster.ResetList();
        Assert.AreEqual(tidy, ActionMaster.Bowl(5));
    }

    [Test]
    public void T03TwoRollsReturnsEndTurn() {
        ActionMaster.ResetList();
        ActionMaster.Bowl(8);
        Assert.AreEqual(endTurn, ActionMaster.Bowl(1));
    }


    [Test]
    public void T04ThreeRolls() {
        ActionMaster.ResetList();
        int[] bowls = { 2, 3 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(5));
    }

    [Test]
    public void T05FourRolls() {
        ActionMaster.ResetList();
        int[] bowls = { 2, 3, 5 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(endTurn, ActionMaster.Bowl(5));
    }

    [Test]
    public void T06StrikeFirstBowlOfFrame() {
        ActionMaster.ResetList();
        int[] bowls = { 5, 3, 10, 5, 0, 10 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(5));
    }

    [Test]
    public void T07WTFFFF() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 2, 3, 4, 0, 10, 10 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(5));
    }

    [Test]
    public void T08ThreeStrikesInARow() {
        ActionMaster.ResetList();
        int[] bowls = { 10, 10 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(endTurn, ActionMaster.Bowl(10));
    }


    [Test]
    public void T09ThreeSparesInARow() {
        ActionMaster.ResetList();
        int[] bowls = { 0, 0 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(0));
    }


    [Test]
    public void T10TwoStrikesInARow() {
        ActionMaster.ResetList();
        ActionMaster.Bowl(10);
        Assert.AreEqual(endTurn, ActionMaster.Bowl(10));
    }

    [Test]
    public void T11TwoStrikesInARowThenSingle() {
        ActionMaster.ResetList();
        int[] bowls = { 10, 10 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(1));
    }

    [Test]
    public void T12SpareThenStrike() {
        ActionMaster.ResetList();
        int[] bowls = { 0, 10, 10 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(5));
    }

    [Test]
    public void T13SpareThenStrikeOneUpped() {
        ActionMaster.ResetList();
        int[] bowls = { 0, 10, 10, 10 };
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(5));
    }

    [Test]
    public void T14LastFrameCheckStrike() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(reset, ActionMaster.Bowl(10));
    }

    [Test]
    public void T15LastFrameCheckSingle() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(9));
    }

    [Test]
    public void T16LastFrameCheckMiss() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(9));
    }

    [Test]
    public void T17LastFrameTwoRollsPickUpSpare() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 2, 3, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 19 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(reset, ActionMaster.Bowl(9));
    }

    [Test]
    public void T18EndGameAtBowlTwenty() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 2, 3, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 19 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(endGame, ActionMaster.Bowl(8));
    }

    [Test]
    public void T19LastFrameStrikeThenSingle() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 }; // 19 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(tidy, ActionMaster.Bowl(1));
    }

    [Test]
    public void T20LastFrameStrikeThenTwoRolls() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1 }; // 19 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(endGame, ActionMaster.Bowl(1));
    }


    [Test]
    public void T21LastFrameTwoStrikes() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(reset, ActionMaster.Bowl(10));
    }


    [Test]
    public void T22LastFrameTwoSingles() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(endGame, ActionMaster.Bowl(1));
    }

    [Test]
    public void T23LastFrameMissThenStrike() {
        ActionMaster.ResetList();
        int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(reset, ActionMaster.Bowl(10));
    }

    [Test]
    public void T24YouTUbeScores() {
        ActionMaster.ResetList();
        int[] bowls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 }; // 18 bowls
        foreach (var bowl in bowls) {
            ActionMaster.Bowl(bowl);
        }
        Assert.AreEqual(endGame, ActionMaster.Bowl(9));
    }
}
