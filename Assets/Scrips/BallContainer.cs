using UnityEngine;

public class BallContainer : MonoBehaviour
{
    [SerializeField] private ButtonPause _buttonPause;
    [SerializeField] private ButtonRestart _buttonRestart;

    public ButtonPause ButtonPause => _buttonPause;
    public ButtonRestart ButtonRestart => _buttonRestart;
}
