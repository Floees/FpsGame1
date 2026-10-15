using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //public Button Button;
    public Image Icon;
    public Image SelectedIcon;
    public TextMeshProUGUI Label;

    //public void Bind(int index, Inventory inv) 
    //{
    //    Button.onClick.AddListener(() => inv.Select(index));
    //}

    public void Render(ItemData item, int amount, bool selected, int number) 
    {
        //Button.interactable = item != null;
        Icon.sprite = item != null ? item.Icon : null;
        Icon.enabled = Icon.sprite != null;
        string name = item != null ? item.DisplayName + " x" + amount : "Empty";
        Label.text = number + ". " + name;
        SelectedIcon.gameObject.SetActive(selected);
        SelectedIcon.enabled = selected;

    }
}