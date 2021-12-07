using UnityEngine;

public class ButtonRestart : ButtonOnClick
{
   [SerializeField] private GameManager _gameManager;


    protected override void OnClick()
    {
        _gameManager.ButtonClickRestartGame(); 
    }
}
