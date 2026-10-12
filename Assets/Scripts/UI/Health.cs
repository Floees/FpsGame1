using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100, CurrentHealth = 100;
    public int Max => Mathf.Max(1, MaxHealth);
    public int Current => Mathf.Clamp(Current, 0, Max);
    public event Action<int, int> HealthChanged;

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
