using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI text;
    [SerializeField] GameObject VictoryCondition;
    int score;
    public GameObject cage;

    

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }

        cage.SetActive(true);
    }

    private void Update()
    {
        OpenCage();
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString() + "/4 ";       
    }

    private void OpenCage()
    {
        if(score >= 4)
        {
            cage.SetActive(false);
        }
    }
}
