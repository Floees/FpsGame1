using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100, CurrentHealth = 100;
    public int Max => Mathf.Max(1, MaxHealth);
    public int Current => Mathf.Clamp(CurrentHealth, 0, Max);
    public event Action<int, int> HealthChanged;
    public bool TakeDmg, HealMe;

    private void Update()
    {
        if (TakeDmg)
        {
            TakeDmg = false;
            TakeDamage(25);
        }
        if (HealMe)
        {
            HealMe = false;
            Heal(25);
        }
    }

    public void TakeDamage(int Amount) 
    {
        if (Amount <= 0)
            return;

        SetHealth(Current -Amount);
    }

    public void Heal(int Amount) 
    {
        if(Amount <= 0)
            return;

        SetHealth(Current + Amount);
    }

    void SetHealth(int value) 
    {
        int next = Mathf.Clamp(value, 0, Max); //avrundar decimaler
        if (next == Current)
            return;

        CurrentHealth = next;
        HealthChanged?.Invoke(Current, Max);
    }



}
