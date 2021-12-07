using UnityEngine;

public class ButtonRestart : ButtonOnClick
{
   [SerializeField] private GameManadger _gameMenedger;


    protected override void OnClick()
    {
        _gameMenedger.ButtonClickRestartGame(); 
    }
}
