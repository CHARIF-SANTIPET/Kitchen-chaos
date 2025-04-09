
using UnityEngine;

public class ContainerCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    private KitchenObject kitchenObject;
    private Animator animator;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource open;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Interact(Player player)
    {
        //if (player.HasKitchenObject()) { Debug.Log("Has item"); }
        KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();

        if (kitchenObject == null)
        {
            animator.SetTrigger("OpenClose");
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.name = kitchenObjectTransform.name.Replace("(Clone)", "").Trim();
            kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObject = kitchenObjectTransform.transform.GetComponent<KitchenObject>();
            open.Play();
        }
        else
        {
            if (!player.HasKitchenObject())
            {
                kitchenObject.transform.SetParent(player.transform);
                kitchenObject.transform.parent = player.GetKitchenObjectFollowTransform();
                kitchenObject.transform.localPosition = Vector3.zero;
                ClearKitchenObject();
                sound.Play();
            } else
            {
                if(player.HasPlate() && kitchenObject.GetKitchenObjectname() == "Bread")
                {
                    playerKitchenObject.AddHamburg(kitchenObject);
                    sound.Play();
                }
            }
        }
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
}
