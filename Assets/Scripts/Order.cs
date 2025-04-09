using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Order : MonoBehaviour 
{
    [SerializeField] public List<KitchenObject> salad;
    [SerializeField] public List<KitchenObject> burger;
    [SerializeField] public List<KitchenObject> cheeseBurger;
    [SerializeField] public List<KitchenObject> MegaBurger;
    [SerializeField] public List<KitchenObject> burgerVegen;
    [SerializeField] public List<KitchenObject> fullBurger;

    public List<List<KitchenObject>> numOrder;

    public List<string> name;

    private void Awake()
    {
        name = new List<string>();
        name.Add("Salad");
        name.Add("Burger");
        name.Add("CheeseBurger");
        name.Add("MegaBurger");
        name.Add("BurgerVegen");
        name.Add("HealtyBurger");
        numOrder = new List<List<KitchenObject>>();
        numOrder.Add(salad);
        numOrder.Add(burger);
        numOrder.Add(cheeseBurger);
        numOrder.Add(MegaBurger);
        numOrder.Add(burgerVegen);
        numOrder.Add(fullBurger);
    }
}
