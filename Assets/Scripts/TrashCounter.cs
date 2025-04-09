using UnityEngine;

public class TrashCounter : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] AudioSource sound;

    public void Interact(Player player)
    {
        
        if (player.HasKitchenObject())
        {
            //Debug.Log("Has item");
            KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();

            if (playerKitchenObject != null)
            {
                
                sound.Play();
                //Debug.Log("Throw Item!");
                playerKitchenObject.transform.SetParent(this.transform);
                playerKitchenObject.transform.parent = counterTopPoint;
                playerKitchenObject.transform.localPosition = Vector3.zero;

                KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
                Destroy(kitchenObject.gameObject);
            }

        }

    }
}
