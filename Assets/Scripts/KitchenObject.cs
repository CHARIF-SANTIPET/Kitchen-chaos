using System.Collections.Generic;

using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] public KitchenObjectSO kitchenobject;
    [SerializeField] public List<KitchenObject> hamburg;


    public string GetKitchenObjectname() {
        return kitchenobject.objectname;
    }


    bool hasMeat = false;

    
    public void AddHamburg(KitchenObject kitchenObject)
    {
        
        if (!hamburg.Contains(kitchenObject) && this.GetKitchenObjectname() == "Plate")
        {
         
            //Debug.Log("Place item in Plate");
            
            if (kitchenObject.GetKitchenObjectname() == "Bread")
            {
                //Debug.Log("Place Bread in Plate");
                hamburg.Add(kitchenObject);
                kitchenObject.transform.parent = this.transform;
                kitchenObject.transform.localPosition = new Vector3(0, 0f, 0);
            }
            else if (!hasMeat &&  (kitchenObject.GetKitchenObjectname() == "MeatCooked" || kitchenObject.GetKitchenObjectname() == "MeatBurned"))
            {
                //Debug.Log("Place MeatCooked in Plate");
                hasMeat = true;
                hamburg.Add(kitchenObject);
                kitchenObject.transform.parent = this.transform;
                kitchenObject.transform.localPosition = new Vector3(0, 0.13f, 0);
                
                
            }
            else if (kitchenObject.GetKitchenObjectname() == "TomatoSlices")
            {
                //Debug.Log("Place TomatoSlices in Plate");
                hamburg.Add(kitchenObject);
                kitchenObject.transform.parent = this.transform;
                kitchenObject.transform.localPosition = new Vector3(0, 0.23f, 0);
            }
            else if (kitchenObject.GetKitchenObjectname() == "CheeseSlice")
            {
                //Debug.Log("Place CheeseSlice in Plate");
                hamburg.Add(kitchenObject); ;
                kitchenObject.transform.SetParent(this.transform);
                kitchenObject.transform.localPosition = new Vector3(0, 0.28f, 0);
            }
            else if (kitchenObject.GetKitchenObjectname() == "CabbageSlice")
            {
                //Debug.Log("Place CabbageSlice in Plate");
                //hamburg.Insert(4, playerKitchenObject);
                hamburg.Add(kitchenObject);
                kitchenObject.transform.parent = this.transform;
                kitchenObject.transform.localPosition = new Vector3(0, 0.25f, 0);

            }
        }
    }

    public override bool Equals(object other)
    {
        if (other is KitchenObject otherObject)
        {
            return this.GetKitchenObjectname() == otherObject.GetKitchenObjectname();
        }
        return false;
    }

    public override int GetHashCode()
    {
        return GetKitchenObjectname().GetHashCode();
    }
}
