using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Bag", menuName="Items/Bag",order=1)]
public class Bag : ScriptableObject, IUseable {

	private int slots;

	[SerializeField] private GameObject bagPrefab;

	public BagScript MyBagScript { get; set;}

	public int Slots {
		get {
			return slots;
		}
	}

	public void Initialize(int slots){
		this.slots = slots;
	}


	#region IUseable implementation
	public void Use ()
	{
		//MyBagScript = Instantiate (bagPrefab, InventoryScript.MyInstance.transform).GetComponent<BagScript> ();
		//MyBagScript.AddSlots (slots);
	}

	public Sprite MyIcon {
		get {
			throw new System.NotImplementedException ();
		}
	}
	#endregion

}