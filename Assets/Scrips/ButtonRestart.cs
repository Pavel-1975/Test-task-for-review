using UnityEngine;
using UnityEngine.Events;

public class ButtonRestart : ButtonOnClick
{
   [SerializeField] private GameMenedger _gameMenedger;

    public event UnityAction RestartGame;


    protected override void OnClick()
    {
        _gameMenedger.RestartGame();

        RestartGame?.Invoke();
    }
}
