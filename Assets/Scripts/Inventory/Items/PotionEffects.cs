using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    public Health PlayerHealth;
    public bool stackEffects;

    float speedFactor = 1f, jumpFactor = 1f;
    float speedUntil, jumpUntil;

    public float SpeedMultiplier => Time.time < speedUntil ? speedFactor : 1f; // om time är mindre än speeduntil ge speedfactor
    public float JumpMultiplier => Time.time < jumpUntil ? jumpFactor : 1f;

    public bool TryUse(ItemData item)
    {
        if(item.Kind == ItemKind.HealthPotion)
        {
            if (PlayerHealth.Current >= PlayerHealth.Max || item.HealAmount <= 0)
                return false;

            PlayerHealth.Heal(item.HealAmount);
            return true;
        }

        if (item.Kind == ItemKind.SpeedPotion)
            SetSpeed(item.Multiplier, item.Duration);

        else if (item.Kind == ItemKind.JumpPotion)
            SetJump(item.Multiplier, item.Duration);

        else return false;

        return true;
    }

    void SetSpeed(float factor, float duration)
    {
        bool active = Time.time < speedUntil;
        speedFactor = stackEffects && active ? speedFactor * factor : factor;
        speedUntil = Time.time + duration;

    }

    void SetJump(float Factor, float duration)
    {
        bool active = Time.time < jumpUntil;
        jumpFactor = stackEffects && active ? jumpFactor * Factor : Factor;
        jumpUntil = Time.time + duration;
    }

}
