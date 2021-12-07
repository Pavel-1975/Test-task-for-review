using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class LifeSlider : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private Slider _slider;


    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _gameManager.MaxLife;
    }

    private void ShowDamage(int value)
    {
        _slider.value = value;
    }

    private void OnEnable()
    {
        _gameManager.TransferDamage += ShowDamage;
    }

    private void OnDisable()
    {
        _gameManager.TransferDamage -= ShowDamage;
    }
}
