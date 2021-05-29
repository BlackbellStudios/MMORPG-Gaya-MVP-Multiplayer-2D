using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
public class Item : ScriptableObject
{

  [Header("Item")]
  public Sprite dropIcon;
  public string dropName;
  public string dropDescr;
  public int dropID;
  public bool isUnique = false;                        //  Optional checkbox to indicate that there should only be one of these items per game
  public bool isIndestructible = false;                //  Optional checkbox to prevent an item from being destroyed by the player (unimplemented)
  public bool isQuestItem = false;                     //  Examples of additional information that could be held in InventoryItem
  public bool isStackable = false;                     //  Examples of additional information that could be held in InventoryItem
  public bool destroyOnUse = false;

  [Header("Properties")]
  public string dropType;
  public string dropClass;
  public int dropBuy;
  public int dropSell;
  public int dropWeight;
  public int dropAttack;
  public int dropRequiredLvl;
  public int dropWeaponLvl;
  public int dropSlot;

}

