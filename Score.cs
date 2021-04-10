using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Namespace used for TextMeshPro objects

public class Score : MonoBehaviour
{
    public float score = 0f;

    private void Update()
    {
        GetComponent<TMP_Text>().text = score.ToString("0");
    }
    public void AddScore()
    {
        score += .25f;
    }
    
}
