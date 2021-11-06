using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class LifeSlider : MonoBehaviour
{
    [SerializeField] private GameMenedger _gameMenedger;

    private Slider _slider;


    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.maxValue = _gameMenedger.MaxLife;
    }

    private void ShowDamage(int value)
    {
        _slider.value = value;
    }

    private void OnEnable()
    {
        _gameMenedger.TransferDamage += ShowDamage;
    }

    private void OnDisable()
    {
        _gameMenedger.TransferDamage -= ShowDamage;
    }
}
