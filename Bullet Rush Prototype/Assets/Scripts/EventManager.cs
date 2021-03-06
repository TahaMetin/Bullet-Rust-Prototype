using UnityEngine;
using UnityEngine.Events;


public class EventManager : Singleton<EventManager>
{
    public UnityEvent lose,win,stop;
    private void Start()
    {
        UIManager uiManager = UIManager.Instance;
        lose.AddListener(uiManager.ShowLosePopup);
        win.AddListener(uiManager.ShowWinPopup);
        stop.AddListener(uiManager.ShowStopPopup);
    }
}
