using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryInput : MonoBehaviour
{
    public Inventory PlayerInventory;
    public PotionEffects Effects;

    private void Update()
    {
        SelectItem();
        UseItem();
    }

    public void SelectItem() 
    {
        if (Keyboard.current == null)
            return;

        var k = Keyboard.current;

        if (k.digit1Key.wasPressedThisFrame)
            PlayerInventory.Select(0);

        if (k.digit2Key.wasPressedThisFrame)
            PlayerInventory.Select(1);

        if (k.digit3Key.wasPressedThisFrame)
            PlayerInventory.Select(2);

        if (k.digit4Key.wasPressedThisFrame)
            PlayerInventory.Select(3);

        if (k.digit5Key.wasPressedThisFrame)
            PlayerInventory.Select(4);

        if (k.digit6Key.wasPressedThisFrame)
            PlayerInventory.Select(5);

        float scroll = Mouse.current != null ? Mouse.current.scroll.ReadValue().y : 0;

        if (scroll > 0f)
            PlayerInventory.SelectNext(1);

        else if (scroll < 0f)
            PlayerInventory.SelectNext(-1);

    }

    public void UseItem()
    {
        if (Mouse.current?.rightButton.wasPressedThisFrame != true)
            return;

        ItemData item = PlayerInventory.Active;

        if (item == null)
            return;
        if (Effects.TryUse(item))
            PlayerInventory.ConsumeSelected();
    }
}
