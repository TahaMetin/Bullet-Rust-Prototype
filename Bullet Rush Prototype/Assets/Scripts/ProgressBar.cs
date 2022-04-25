using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : Singleton<ProgressBar>
{
    public int max, current;
    public Image mask;
    public GameObject enemys;
    private bool isGameRunning;
    [SerializeField] GameObject numberOfRemainingEnemy_GO;
    Text numberOfRemainingEnemy_Text;
    private void Start()
    {
        SetMaxEnemyCount();
        numberOfRemainingEnemy_Text = numberOfRemainingEnemy_GO.GetComponent<Text>();
    }

    private void Update()
    {
        if (!isGameRunning)
            return;

        int activeEnemyCount = 0;
        for (int i = 0; i < enemys.transform.childCount; i++)
        {
            if (enemys.transform.GetChild(i).gameObject.activeInHierarchy)
                activeEnemyCount++;
        }
        current = activeEnemyCount; // set current active enemy number
        numberOfRemainingEnemy_Text.text = current.ToString();
        SetCurrentFill();
    }
    public void SetCurrentFill() 
    {
        float fillAmount =1.0f - ((float)current / (float)max );
        mask.fillAmount = fillAmount;
        
        if(current  == 0)  // if there is no enemy alive end the game
        {
            numberOfRemainingEnemy_Text.text = current.ToString();
            mask.fillAmount = 0f;
            EventManager.Instance.win.Invoke();
            isGameRunning = false;
        }
    }

    public void SetMaxEnemyCount()
    {
        int activeEnemyCount = 0;
        for (int i = 0; i < enemys.transform.childCount; i++)
        {
            if (enemys.transform.GetChild(i).gameObject.activeInHierarchy)
                activeEnemyCount++;
        }
        max = activeEnemyCount;
        isGameRunning = true;
    }

}
