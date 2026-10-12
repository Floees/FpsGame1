using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    public Inventory PlayerInventory;
    public TextMeshProUGUI Prompt;
    List<PotionPickup> Nearby = new();
    PotionPickup Focus => Nearby.Count > 0 ? Nearby[Nearby.Count - 1] : null; //Tar första bästa eller inget

    private void Update()
    {
        UpdatePrompt();
        TryPickup();
    }

    public void Register(PotionPickup potion)
    {
        if (!Nearby.Contains(potion))
            Nearby.Add(potion);
    }

    public void Unregister(PotionPickup potion) => Nearby.Remove(potion);

    void UpdatePrompt() 
    {
        Nearby.RemoveAll(p => p == null || !p.gameObject.activeInHierarchy);
        string text = "";

        if (Focus != null) 
        {
            text = !PlayerInventory.CanAdd(Focus.Data) ? "Inventory full" : "Press E to Pickup:" + Focus.Data.DisplayName;
        }
        if(Prompt.text != text)
            Prompt.text = text;

        Prompt.enabled = text.Length > 0;
    }

    void TryPickup() 
    {
        if (Focus == null)
            return;

        if (Keyboard.current?.eKey.wasPressedThisFrame != true)
            return;

        Focus.TryPickup(PlayerInventory);
        UpdatePrompt();
    }
}
