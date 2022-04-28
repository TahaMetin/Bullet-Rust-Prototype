using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    /*  Responsible to win and lose popups
     *  and buttons related
     */
    [SerializeField] GameObject winPopup, losePopup, stopPopup;
    public void ShowWinPopup() { winPopup.SetActive(true);    }
    public void ShowLosePopup() { losePopup.SetActive(true);  }
    public void ShowStopPopup() { stopPopup.SetActive(true);  }
    public void HideWinPopup() { winPopup.SetActive(false);   }
    public void HideLosePopup() { losePopup.SetActive(false); }
    public void HideStopPopup() { stopPopup.SetActive(false); }
}
