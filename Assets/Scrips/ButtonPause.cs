using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : ButtonOnClick
{
    [SerializeField] private Image _panel;
    [SerializeField] private GameManager _gameMeneger;


    protected override void OnClick()
    {
        if (_gameMeneger.LivesRemained)
            Pause();
    }

    private void OnPause()
    {
        Pause();
    }

    private void Pause()
    {
        _panel.transform.gameObject.SetActive(_gameMeneger.GetPauseState());
    }

    private void Start()
    {
        _gameMeneger.Pause += OnPause;
    }

    private void OnApplicationQuit()
    {
        _gameMeneger.Pause -= OnPause;
    }
}
