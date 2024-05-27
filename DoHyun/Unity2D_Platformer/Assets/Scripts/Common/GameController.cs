using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIGamePopup uiGamePopup;
    private bool isLevelFailed = false;

    public void LevelFailed()
    {
        if (isLevelFailed == true) return;
        isLevelFailed = true;
        uiGamePopup.LevelFailed();
    }
}
