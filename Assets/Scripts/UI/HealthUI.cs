using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health PlayerHealth;
    public Slider SliderBar;
    public TextMeshProUGUI Label;

    void Render(int current, int max) 
    {
        Label.text = $"Life: {current}/{max}";
        SliderBar.SetValueWithoutNotify(current);

    }

    private void OnEnable()
    {
        PlayerHealth.HealthChanged += Render; //subscribar till event
        Render(PlayerHealth.Current, PlayerHealth.Max); //förstätter vilka värden metoden använder
    }

    private void OnDisable() // om man inte avsubscribar så blir det flera instanser.
    {
        if(PlayerHealth != null)
            PlayerHealth.HealthChanged -= Render;
    }

}
