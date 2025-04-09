using System.Collections.Generic;

using UnityEngine;

public class PlateCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    List<KitchenObject> plates = new List<KitchenObject>();
    private KitchenObject kitchenObject;
    void Start()
    {
        SpawnPlate();
        kitchenObject = plates[0];
    }

    public void Interact(Player player)
    {
        if (!player.HasKitchenObject() && kitchenObject != null)
        {
            plates[plates.Count - 1].transform.SetParent(player.transform);
            kitchenObject.transform.parent = player.GetKitchenObjectFollowTransform();
            kitchenObject.transform.localPosition = Vector3.zero;
            //ClearKitchenObject(); 
            plates.RemoveAt(plates.Count - 1);
            SelectPlate();
        }

    }

    public void SpawnPlate()
    {
        if(plates.Count < 4)
        {
            KitchenObject plateobj;
            if (plates.Count == 0)
            {
                Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
                kitchenObjectTransform.localPosition = Vector3.zero;
                plateobj = kitchenObjectTransform.transform.GetComponent<KitchenObject>();
                plates.Add(plateobj);
            } else
            {
                Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
                kitchenObjectTransform.localPosition = new Vector3(0, ((float)plates.Count)/10f, 0);
                plateobj = kitchenObjectTransform.transform.GetComponent<KitchenObject>();
                plates.Add(plateobj);
            }
            kitchenObject = plates[plates.Count - 1];
        }
        Invoke("SpawnPlate", 5);
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public void SelectPlate()
    {
        if(plates.Count > 0)
        {
            kitchenObject = plates[plates.Count-1];
        } else
        {
            kitchenObject = null ;
        }
    }
}
