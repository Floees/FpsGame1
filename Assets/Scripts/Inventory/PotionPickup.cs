using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PotionPickup : MonoBehaviour
{

    public ItemData item;
    [Min(1)] public int amount = 1;
    public UnityEvent Picked = new();
    PlayerInteractor Player;
    public ItemData Data => item;

    private void OnDisable() => ClearPlayer();

    private void OnTriggerEnter(Collider other)
    {
        var inter = other.GetComponentInParent<PlayerInteractor>();
        
        if (inter == null)
            return;

        Player = inter;
        Player.Register(this);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<PlayerInteractor>() != Player)
            return;

        ClearPlayer();
    }

    public bool TryPickup(Inventory inv) 
    {
        if (!inv.TryAdd(item, amount))
            return false;

        Picked.Invoke();
        gameObject.SetActive(false);
        return true;
    }

    void ClearPlayer() 
    {
        if (Player != null)
            Player.Unregister(this);

        Player = null;
    }
}