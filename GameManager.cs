using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    //This is a coroutine. System.Collections is needed for this
    IEnumerator RestartLevel()
    {
        //Before 1 second
        //timeScale is the pace at which scripts run. By default it is 1
        Time.timeScale = 1f / slowness;
        //Change the fixedDeltaTime to the same value as timeScale to make it run smoothly
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        //WaitForSeconds is also affected by timeScale
        yield return new WaitForSeconds(1f / slowness);

        //Changes the timeScale back to normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        //After 1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
