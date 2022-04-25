using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : Singleton<ProgressBar>
{
    [SerializeField] Image mask;
    [SerializeField] GameObject enemys;
    [SerializeField] GameObject numberOfRemainingEnemy_GO;
    Text _numberOfRemainingEnemy_Text;
    bool _isGameRunning;
    int _max, _current;
    private void Start()
    {
        SetMaxEnemyCount();
        _numberOfRemainingEnemy_Text = numberOfRemainingEnemy_GO.GetComponent<Text>();
    }

    private void Update()
    {
        if (!_isGameRunning)
            return;

        int activeEnemyCount = 0;
        for (int i = 0; i < enemys.transform.childCount; i++)
        {
            if (enemys.transform.GetChild(i).gameObject.activeInHierarchy)
                activeEnemyCount++;
        }
        _current = activeEnemyCount; // set current active enemy number
        _numberOfRemainingEnemy_Text.text = _current.ToString();
        SetCurrentFill();
    }
    public void SetCurrentFill() 
    {
        float fillAmount =1.0f - ((float)_current / (float)_max );
        mask.fillAmount = fillAmount;
        
        if(_current  == 0)  // if there is no enemy alive end the game
        {
            _numberOfRemainingEnemy_Text.text = _current.ToString();
            mask.fillAmount = 0f;
            EventManager.Instance.win.Invoke();
            _isGameRunning = false;
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
        _max = activeEnemyCount;
        _isGameRunning = true;
    }

}
