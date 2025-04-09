using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float rotatespeed = 8f;
    [SerializeField] private Transform holdPoint;
    
    private bool isWalking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 targetPosition = transform.position + moveDir * movespeed * Time.deltaTime;

        // ใช้ Lerp เพื่อเคลื่อนที่ไปยังตำแหน่งเป้าหมายอย่างนุ่มนวล
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);

        // ตรวจสอบว่าตัวละครกำลังเดินอยู่หรือไม่
        isWalking = moveDir != Vector3.zero;

        // หมุนตัวละครให้หันไปทางที่เดินอย่างนุ่มนวล
        if (isWalking)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * rotatespeed);
        }
    }


    public bool IsWalking()
    {
        return isWalking;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Counter")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            ClearCounter clearcounter = collision.gameObject.GetComponent<ClearCounter>();
            clearcounter.Interact(this);
        }
        else if (collision.gameObject.tag == "Container")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            ContainerCounter containercounter = collision.gameObject.GetComponent<ContainerCounter>();
            containercounter.Interact(this);
            //Debug.Log(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Cutting")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            CuttingCounter containercounter = collision.gameObject.GetComponent<CuttingCounter>();
            containercounter.Interact(this);
            //Debug.Log(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Trash")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            TrashCounter trashCounter = collision.gameObject.GetComponent<TrashCounter>();
            trashCounter.Interact(this);
            //Debug.Log(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "PlateCounter")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            PlateCounter trashCounter = collision.gameObject.GetComponent<PlateCounter>();
            trashCounter.Interact(this);
            //Debug.Log(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Stove")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            StoveCounter stoveCounter = collision.gameObject.GetComponent<StoveCounter>();
            stoveCounter.Interact(this);
            //Debug.Log(collision.gameObject.name);
        }
        else if (collision.gameObject.tag == "Delivery")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(true);
            DeliveryCounter DeliveryCounter = collision.gameObject.GetComponent<DeliveryCounter>();
            DeliveryCounter.Interact(this);
        }
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (collision.gameObject.tag == "Counter")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            ClearCounter clearcounter = collision.gameObject.GetComponent<ClearCounter>();
    //            clearcounter.Interact(this);
    //        }
    //        else if (collision.gameObject.tag == "Container")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            ContainerCounter containercounter = collision.gameObject.GetComponent<ContainerCounter>();
    //            containercounter.Interact(this);
    //            //Debug.Log(collision.gameObject.name);
    //        }
    //        else if (collision.gameObject.tag == "Cutting")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            CuttingCounter containercounter = collision.gameObject.GetComponent<CuttingCounter>();
    //            containercounter.Interact(this);
    //            //Debug.Log(collision.gameObject.name);
    //        }
    //        else if (collision.gameObject.tag == "Trash")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            TrashCounter trashCounter = collision.gameObject.GetComponent<TrashCounter>();
    //            trashCounter.Interact(this);
    //            //Debug.Log(collision.gameObject.name);
    //        }
    //        else if (collision.gameObject.tag == "PlateCounter")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            PlateCounter trashCounter = collision.gameObject.GetComponent<PlateCounter>();
    //            trashCounter.Interact(this);
    //            //Debug.Log(collision.gameObject.name);
    //        }
    //        else if (collision.gameObject.tag == "Stove")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            StoveCounter stoveCounter = collision.gameObject.GetComponent<StoveCounter>();
    //            stoveCounter.Interact(this);
    //            //Debug.Log(collision.gameObject.name);
    //        }
    //        else if (collision.gameObject.tag == "Delivery")
    //        {
    //            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
    //            selectedCounter.gameObject.SetActive(true);
    //            DeliveryCounter DeliveryCounter = collision.gameObject.GetComponent<DeliveryCounter>();
    //            DeliveryCounter.Interact(this);
    //        }
    //    }
    //}

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Counter" || collision.gameObject.tag == "Container" || collision.gameObject.tag == "Cutting" || collision.gameObject.tag == "Trash" || collision.gameObject.tag == "PlateCounter" || collision.gameObject.tag == "Stove" || collision.gameObject.tag == "Delivery")
        {
            Transform selectedCounter = collision.gameObject.transform.Find("Selected");
            selectedCounter.gameObject.SetActive(false);
            //Debug.Log(collision.gameObject.name);
        }
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return holdPoint;
    }
    public bool HasKitchenObject()
    {
        KitchenObject playerKitchenObject = this.GetComponentInChildren<KitchenObject>();
        return playerKitchenObject != null;
    }

    public bool HasPlate()
    {
        KitchenObject playerKitchenObject = this.GetComponentInChildren<KitchenObject>();
        if(playerKitchenObject != null)
        {
            return playerKitchenObject.GetKitchenObjectname() == "Plate";
        }
        return false;
    }
}
