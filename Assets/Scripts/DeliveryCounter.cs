using System.Collections.Generic;
using UnityEngine;


public class DeliveryCounter : MonoBehaviour
{

    OrderGenerate OrderGenerate;
    [SerializeField] Animator popUpSuccess;
    [SerializeField] AudioSource successSound;
    [SerializeField] AudioSource failSound;
    [SerializeField] Animator popUpFail;





    private void Awake()
    {
        OrderGenerate = FindAnyObjectByType<OrderGenerate>();
        //popUp = GetComponentInChildren<Animator>();
        popUpSuccess.gameObject.SetActive(false);
        popUpFail.gameObject.SetActive(false);

    }

    public void Interact(Player player)
    {
        KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();
        if(playerKitchenObject != null)
        {
            Debug.Log("DELIVERY :"+ string.Join(",", playerKitchenObject.hamburg));
            if (CheckOrder(playerKitchenObject))
            {
                OrderGenerate.OrderSuccess();
                popUpSuccess.gameObject.SetActive(true);
                popUpSuccess.SetTrigger("Popup");
                successSound.Play();

                
            }
            else
            {
                popUpFail.gameObject.SetActive(true);
                popUpFail.SetTrigger("Popup");

                Debug.Log("Incorrect Order");
                failSound.Play();
                
            }
            Destroy(playerKitchenObject.transform.gameObject);
        }
    }

    bool CheckOrder(KitchenObject playerOBJ)
    {
        bool orderSuccess = false;

        if (playerOBJ != null && playerOBJ.GetKitchenObjectname() == "Plate")
        {
            List<KitchenObject> ordersCopy = new List<KitchenObject>(OrderGenerate.GetOrder());
            List<List<KitchenObject>> orderListCopy = new List<List<KitchenObject>>(OrderGenerate.GetOrderList());

            if (ordersCopy.Count == playerOBJ.hamburg.Count)
            {
                for (int i = ordersCopy.Count - 1; i >= 0; i--)
                {
                    bool foundMatch = false;

                    for (int j = playerOBJ.hamburg.Count - 1; j >= 0; j--)
                    {
                        if (ordersCopy[i].GetKitchenObjectname() == playerOBJ.hamburg[j].GetKitchenObjectname())
                        {
                            ordersCopy.RemoveAt(i);
                            playerOBJ.hamburg.RemoveAt(j);
                            foundMatch = true;
                            break;
                        }
                    }

                    if (!foundMatch)
                    {
                        continue;
                    }
                }

                if (ordersCopy.Count == 0 && playerOBJ.hamburg.Count == 0)
                {
                    orderSuccess = true;
                }
            }

            //for (int o = orderListCopy.Count - 1; o >= 0; o--) 
            //{
            //    List<KitchenObject> order = new List<KitchenObject>(orderListCopy[o]);
            //    List<KitchenObject> playerHamburg = new List<KitchenObject>(playerOBJ.hamburg);

            //    if (order.Count != playerHamburg.Count)
            //        continue; 

            //    bool isMatch = true;

            //    for (int i = order.Count - 1; i >= 0; i--)
            //    {
            //        bool found = false;

            //        for (int j = playerHamburg.Count - 1; j >= 0; j--)
            //        {
            //            if (order[i].GetKitchenObjectname() == playerHamburg[j].GetKitchenObjectname())
            //            {
            //                order.RemoveAt(i);
            //                playerHamburg.RemoveAt(j);
            //                found = true;
            //                break;
            //            }
            //        }

            //        if (!found)
            //        {
            //            isMatch = false;
            //            break;
            //        }
            //    }

            //    if (isMatch && order.Count == 0 && playerHamburg.Count == 0)
            //    {
            //        OrderGenerate.GetOrderList().RemoveAt(o); 
            //        return true; 
            //    }
            //}
        }

        return orderSuccess;
    }

}
