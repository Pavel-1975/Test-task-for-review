using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : ButtonOnClick
{
    [SerializeField] private Image _panel;
    [SerializeField] private GameManadger _gameMenedger;


    protected override void OnClick()
    {
        if (_gameMenedger.LivesRemained)
            Pause();
    }

    private void OnPause()
    {
        Pause();
    }

    private void Pause()
    {
        _panel.transform.gameObject.SetActive(_gameMenedger.GetPauseState());
    }

    private void Start()
    {
        _gameMenedger.Pause += OnPause;
    }

    private void OnApplicationQuit()
    {
        _gameMenedger.Pause -= OnPause;
    }
}
