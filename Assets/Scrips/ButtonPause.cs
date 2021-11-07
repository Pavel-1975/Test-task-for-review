using UnityEngine;
using UnityEngine.UI;

public class ButtonPause : ButtonOnClick
{
    [SerializeField] private Image _panel;
    [SerializeField] private GameMenedger _gameMenedger;

    public bool IsPause { get; private set; }


    protected override void OnClick()
    {
        if (_gameMenedger.Alive)
            Pause();
    }

    private void OnPause()
    {
        Pause();
    }

    private void Pause()
    {
        IsPause = !IsPause;

        _panel.transform.gameObject.SetActive(IsPause);
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
