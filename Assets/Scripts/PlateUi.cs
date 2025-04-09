using UnityEngine;

public class PlateUi : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
    }


}
