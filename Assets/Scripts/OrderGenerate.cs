using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OrderGenerate : MonoBehaviour
{
    List<List<KitchenObject>> orders;
    List<string> orderNames;

    Order Order;

    [SerializeField] TextMeshProUGUI orderText;


    [SerializeField] private GameObject orderPanel;
    [SerializeField] private GameObject orderRowPrefab;
    [SerializeField] private GameObject orderImagePrefab;
    [SerializeField] private GameObject order;

    //public List<List<KitchenObject>> numOrder ;

    private void Start()
    {
        orders = new List<List<KitchenObject>>();
        orderNames = new List<string>();
        Order = FindAnyObjectByType<Order>();
        RandomOrder();
        //Debug.Log(string.Join(",", orders[0]));
    }

    private void Update()
    {
        //UpdateOrderUI();
    }
    void RandomOrder()
    {
        if(orders.Count < 5)
        {
            int rdOrder = Random.Range(0, Order.numOrder.Count);
            orders.Add(Order.numOrder[rdOrder]);
            orderNames.Add(Order.name[rdOrder]);

        }

        Invoke("RandomOrder", 7);
        UpdateOrderUI();
    }

    public List<KitchenObject> GetOrder()
    {
        return orders[0];
    }

    public List<List<KitchenObject>> GetOrderList()
    {
        return orders;
    }
    public string GetOrderName()
    {
        return orderNames[0];
    }

    public void OrderSuccess()
    {
        orders.RemoveAt(0);
        orderNames.RemoveAt(0);
        Debug.Log(orderNames[0] + " : " + string.Join(",", orders[0]));
        UpdateOrderUI();

    }

    //void UpdateOrderUI()
    //{
    //    orderText.text = "";

    //    for (int i = 0; i < orders.Count; i++)
    //    {
    //        if( orders[i] == null )
    //            break;
    //        orderText.text += "Order " + (i + 1) + ": ";
    //        foreach (var item in orders[i])
    //        {
    //            orderText.text += item.GetKitchenObjectname() + " ";
    //        }
    //        orderText.text += "\n";
    //    }
    //}

    public void UpdateOrderUI()
    {
        foreach (Transform child in orderPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i] == null)
                continue;
            GameObject newOrder = Instantiate(order, orderPanel.transform);
            

            GameObject newRow = Instantiate(orderRowPrefab, newOrder.gameObject.transform.Find("orderImage").transform);
            

            foreach (var item in orders[i])
            {
                newOrder.gameObject.transform.Find("orderName").GetComponent<Text>().text = orderNames[i];
                GameObject newImage = Instantiate(orderImagePrefab, newRow.transform);
                Image imgComponent = newImage.GetComponent<Image>();
                imgComponent.sprite = item.kitchenobject.sprite;
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(orderPanel.GetComponent<RectTransform>());
    }


}
