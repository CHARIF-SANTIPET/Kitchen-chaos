using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.LookAt(Camera.main.transform);
        this.transform.forward = Camera.main.transform.forward;
        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, +12f);


    }

    
}
