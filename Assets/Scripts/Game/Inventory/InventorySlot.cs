
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
  public Image icon;
  public Button removeButton;
  Item item;
  public void AddITem(Item newItem)
  {
    item = newItem;
    icon.sprite = item.dropIcon;
    icon.enabled = true;
    removeButton.interactable = true;
  }

  public void ClearSlot()
  {
    item = null;
    icon.sprite = null;
    icon.enabled = false;
    removeButton.interactable = false;
  }

  public void OnRemoveButton()
  {
    InventoryScript.instance.Remove(item);
  }

  public void UseItem()
  {
    if (item != null)
    {
      //item.Use();
    }
  }
}
