using UnityEngine;

public class StoveCounter : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private CuttingRecipeSO[] cookedRecipeSOArray;
    [SerializeField] private GameObject sizzler;
    [SerializeField] private GameObject stoveRed;
    [SerializeField] private AudioSource sound;
    [SerializeField] Animator stoveBurn;
    private float cuttingProcess;
    private float timer = 0f;
    public float cuttingSpeed = 5f;
    public float knifeSpeed = 0.2f;

    private float cookedProcess;

    public void Start()
    {
        
    }

    private void Update()
    {
        if(cuttingProcess > 0)
        {
            KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
            cuttingProcess += cuttingSpeed * Time.deltaTime;
            Cutting_FX(Time.deltaTime);
            if(kitchenObject != null)
            {
                sizzler.SetActive(true);
                stoveRed.SetActive(true);
                
                if (kitchenObject.GetKitchenObjectname() == "Meat")
                {
                    int cuttingMax = cookedRecipeSOArray[0].cutCount;
                    ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                    float persent_process = (float)(cuttingProcess) / cuttingMax;
                    processBar.CuttingCounter_OnProcessChanged(persent_process);
                    if ((cuttingProcess) >= cuttingMax)
                    {
                        Destroy(kitchenObject.gameObject);
                        Transform sliceTransform = Instantiate(cookedRecipeSOArray[0].to.prefab, counterTopPoint);
                        sliceTransform.name = sliceTransform.name.Replace("(Clone)", "").Trim();
                        sliceTransform.transform.localPosition = Vector3.zero;
                        processBar.CuttingCounter_OnProcessChanged(0f);
                        cuttingProcess = 1;
                    }
                }
                else if (kitchenObject.GetKitchenObjectname() == "MeatCooked")
                {
                    Transform warningUI = this.gameObject.transform.Find("StoveBurnWarningUI");
                    warningUI.gameObject.SetActive(true);
                    //stoveBurn.SetBool("isFlashing", true);

                    int cuttingMax = cookedRecipeSOArray[1].cutCount;
                    ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                    float persent_process = (float)(cuttingProcess) / cuttingMax;
                    processBar.CuttingCounter_OnProcessChanged(persent_process);
                    if ((cuttingProcess) >= cuttingMax)
                    {
                        Destroy(kitchenObject.gameObject);
                        Transform sliceTransform = Instantiate(cookedRecipeSOArray[1].to.prefab, counterTopPoint);
                        sliceTransform.name = sliceTransform.name.Replace("(Clone)", "").Trim();
                        sliceTransform.transform.localPosition = Vector3.zero;
                        processBar.CuttingCounter_OnProcessChanged(0f);
                        cuttingProcess = 0;
                    }
                }
            }
            
        }
    }

    public void Interact(Player player)
    {
        if(player.HasKitchenObject() && !this.HasKitchenObject())
        {
            //Debug.Log("Has item");
            KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();
            //Debug.Log(playerKitchenObject.GetKitchenObjectname());
            cookedProcess = 0;

            if(playerKitchenObject.GetKitchenObjectname() == "Meat")
            {
                sound.Play();
                //Debug.Log("Place Item Cook");
                int cookedMax = cookedRecipeSOArray[0].cutCount;
                playerKitchenObject.transform.parent = counterTopPoint; 
                playerKitchenObject.transform.localPosition = Vector3.zero;
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process =  (float)cookedProcess / cookedMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                cuttingProcess++;
                
                timer = 0f;
            }
        } else
        {
            if (this.HasKitchenObject())
            {

                KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
                
                
                if (kitchenObject.GetKitchenObjectname() != "Meat")
                {
                    if (player.HasPlate())
                    {
                        player.GetComponentInChildren<KitchenObject>().AddHamburg(kitchenObject);
                        ResetStove();
                    } else if (!player.HasKitchenObject())
                    {
                        kitchenObject.transform.SetParent(player.transform);
                        kitchenObject.transform.parent = player.GetKitchenObjectFollowTransform();
                        kitchenObject.transform.localPosition = Vector3.zero;
                        ResetStove();
                        
                    }
                    
                }
                
            }
        }
    }

    void ResetStove()
    {
        Transform warningUI = this.gameObject.transform.Find("StoveBurnWarningUI");
        sound.Stop();
        sizzler.SetActive(false);
        stoveRed.SetActive(false);
        warningUI.gameObject.SetActive(false);
        //stoveBurn.SetBool("isFlashing", false);

        ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
        processBar.CuttingCounter_OnProcessChanged(0f);
        cuttingProcess = 0;
    }
    private void Cutting_FX(float duration)
    {
        timer += duration;
        if (timer >= knifeSpeed)
        {
            timer = 0f;
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
}
