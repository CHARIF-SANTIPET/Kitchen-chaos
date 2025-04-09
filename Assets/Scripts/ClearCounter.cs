
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] AudioSource pickSound;
    [SerializeField] AudioSource dropSound;
    //public List<KitchenObject> kitchenObjects = new List<KitchenObject>();
    

    
    public void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            //Debug.Log("Has item");
            KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();
            

            if (playerKitchenObject != null && !this.HasKitchenObject())
            {
                
                playerKitchenObject.transform.SetParent(this.transform);
                playerKitchenObject.transform.parent = counterTopPoint;
                playerKitchenObject.transform.localPosition = Vector3.zero;
                KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
                dropSound.Play();
                //Debug.Log("Place Item!: " + kitchenObject.GetKitchenObjectname());

            } else if (playerKitchenObject != null && this.HasPlate())
            {
                KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
                dropSound.Pause();
                //Debug.Log("Place Item In Plate!");
                kitchenObject.AddHamburg(playerKitchenObject);
            } else if (playerKitchenObject.GetKitchenObjectname() == "Plate")
            {
                KitchenObject kitchenObject  =this.GetComponentInChildren<KitchenObject>();
                playerKitchenObject.AddHamburg(kitchenObject);
                pickSound.Play();

            }
        }
        else
        {
            KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
            //Debug.Log("Pick up!");
            if (kitchenObject != null)
            {
                pickSound.Play();
                kitchenObject.transform.SetParent(player.transform);
                kitchenObject.transform.parent = player.GetKitchenObjectFollowTransform();
                kitchenObject.transform.localPosition = Vector3.zero;
            }
        }

    }

   

    public Transform GetKitchenObjectFollowTransform() 
    {
        return counterTopPoint;
    }
    public bool HasKitchenObject()
    {
        KitchenObject playerKitchenObject = this.GetComponentInChildren<KitchenObject>();
        return playerKitchenObject != null;
    }

    public bool HasPlate()
    {
        KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
        if(kitchenObject.GetKitchenObjectname() == "Plate")
            return true;
        return false;
    }

}
