using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int max, current;
    public Image mask;
    public GameObject enemys;
    private bool isGameRunning;
    private void Start()
    {
        SetMaxEnemyCount();
        isGameRunning = true;
    }

    private void Update()
    {
        if (!isGameRunning)
            return;
        current = enemys.transform.childCount; // set current enemy number

        GetCurrentFill();
    }
    public void GetCurrentFill() 
    {
        float fillAmount =1.0f - ((float)current / (float)max );
        mask.fillAmount = fillAmount;
        
        if(current  == 0)  // if there is no enemy alive end the game
        {
            mask.fillAmount = 0f;
            UIManager.Instance.GetComponent<UIManager>().ShowWinPopup();
            isGameRunning = false;
        }
    }

    public void SetMaxEnemyCount()
    {
        max = enemys.transform.childCount;
    }

}
