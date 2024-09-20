using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimer : MonoBehaviour
{
    public Text timerText;
    private float matchTime;

    void Start()
    {
        matchTime = GameSettings.matchDuration * 60; // Convert minutes to seconds
        StartCoroutine(StartMatchTimer());
    }

    private IEnumerator StartMatchTimer()
    {
        while (matchTime > 0)
        {
            matchTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.FloorToInt(matchTime / 60).ToString("00") + ":" + Mathf.FloorToInt(matchTime % 60).ToString("00");
            yield return null;
        }

        EndMatch();
    }

    private void EndMatch()
    {
        // Implement logic to end the match, e.g., show game over screen
        Debug.Log("Match Ended");
    }
}
