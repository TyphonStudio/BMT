using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    [SerializeField] protected Image foreground;

    public void SetSlider(float value)
    {
        foreground.fillAmount = value;
    }

    public void SetColor(Color color)
    {
        foreground.color = color;
    }
}