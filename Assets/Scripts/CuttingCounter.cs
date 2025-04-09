
using UnityEngine;

public class CuttingCounter : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    [SerializeField] AudioSource chop;

    public float cuttingSpeed = 5f;
    public float knifeSpeed = 0.2f;
    private float cuttingProcess;
    private Animator animator;
    private float timer = 0f;
    private bool isDone = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (cuttingProcess > 0)
        {
            KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
            cuttingProcess += cuttingSpeed * Time.deltaTime;
            Cutting_FX(Time.deltaTime);
            if (kitchenObject.GetKitchenObjectname() == "Tomato")
            {
                int cuttingMax = cuttingRecipeSOArray[0].cutCount;
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process = (float)(cuttingProcess) / cuttingMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                if ((cuttingProcess) >= cuttingMax)
                {
                    isDone = true;
                    Destroy(kitchenObject.gameObject);
                    Transform sliceTransform = Instantiate(cuttingRecipeSOArray[0].to.prefab, counterTopPoint);
                    sliceTransform.name = sliceTransform.name.Replace("(Clone)", "").Trim();
                    sliceTransform.transform.localPosition = Vector3.zero;
                    processBar.CuttingCounter_OnProcessChanged(0f);
                    cuttingProcess = 0;
                }
            } else if (kitchenObject.GetKitchenObjectname() == "Cheese")
            {
                int cuttingMax = cuttingRecipeSOArray[1].cutCount;
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process = (float)(cuttingProcess) / cuttingMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                if ((cuttingProcess) >= cuttingMax)
                {
                    isDone = true;
                    Destroy(kitchenObject.gameObject);
                    Transform sliceTransform = Instantiate(cuttingRecipeSOArray[1].to.prefab, counterTopPoint);
                    sliceTransform.name = sliceTransform.name.Replace("(Clone)", "").Trim();
                    sliceTransform.transform.localPosition = Vector3.zero;
                    processBar.CuttingCounter_OnProcessChanged(0f);
                    cuttingProcess = 0;
                }
            }
            else if (kitchenObject.GetKitchenObjectname() == "Cabbage")
            {
                int cuttingMax = cuttingRecipeSOArray[2].cutCount;
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process = (float)(cuttingProcess) / cuttingMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                if ((cuttingProcess) >= cuttingMax)
                {
                    isDone = true;
                    Destroy(kitchenObject.gameObject);
                    Transform sliceTransform = Instantiate(cuttingRecipeSOArray[2].to.prefab, counterTopPoint);
                    sliceTransform.name = sliceTransform.name.Replace("(Clone)", "").Trim();
                    sliceTransform.transform.localPosition = Vector3.zero;
                    processBar.CuttingCounter_OnProcessChanged(0f);
                    cuttingProcess = 0;
                }
            }

        }
    }
    private void Cutting_FX(float duration) {
        timer += duration;
        if (timer >= knifeSpeed)
        {
            chop.Play();
            animator.SetTrigger("Cut");
            timer = 0f;
        }
    }

    public void Interact(Player player)
    {
        if (player.HasKitchenObject() && !this.HasKitchenObject())
        {
            //Debug.Log("Has item");
            KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();
            //Debug.Log(playerKitchenObject.GetKitchenObjectname());
            cuttingProcess = 0;
            if (playerKitchenObject.GetKitchenObjectname() == "Tomato")
            {
                //Debug.Log("Slice Tomato!");
                int cuttingMax = cuttingRecipeSOArray[0].cutCount;
                playerKitchenObject.transform.parent = counterTopPoint;
                playerKitchenObject.transform.localPosition = Vector3.zero;
                //Debug.Log(cuttingMax);
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process= (float)cuttingProcess / cuttingMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                cuttingProcess++;
                animator.SetTrigger("Cut");
                timer = 0f;
            } else if (playerKitchenObject.GetKitchenObjectname() == "Cheese")
            {
                //Debug.Log("Slice Cheese!");
                int cuttingMax = cuttingRecipeSOArray[1].cutCount;
                playerKitchenObject.transform.parent = counterTopPoint;
                playerKitchenObject.transform.localPosition = Vector3.zero;
                //Debug.Log(cuttingMax);
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process = (float)cuttingProcess / cuttingMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                cuttingProcess++;
                animator.SetTrigger("Cut");
                timer = 0f;
            } else if (playerKitchenObject.GetKitchenObjectname() == "Cabbage")
            {
                //Debug.Log("Slice Cabbage!");
                int cuttingMax = cuttingRecipeSOArray[2].cutCount;
                playerKitchenObject.transform.parent = counterTopPoint;
                playerKitchenObject.transform.localPosition = Vector3.zero;
                //Debug.Log(cuttingMax);
                ProcessBar processBar = this.GetComponentInChildren<ProcessBar>();
                float persent_process = (float)cuttingProcess / cuttingMax;
                processBar.CuttingCounter_OnProcessChanged(persent_process);
                cuttingProcess++;
                animator.SetTrigger("Cut");
                timer = 0f;
            }

        }
        else {
            if (this.HasKitchenObject() && isDone )
            {
                if(player.HasKitchenObject())
                {
                    if (player.HasPlate())
                    {
                        KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
                        KitchenObject playerKitchenObject = player.GetComponentInChildren<KitchenObject>();
                        if (!playerKitchenObject.hamburg.Contains(kitchenObject))
                        {
                            playerKitchenObject.AddHamburg(kitchenObject);
                            isDone = false;
                        }                       
                    }
                } else
                {
                    KitchenObject kitchenObject = this.GetComponentInChildren<KitchenObject>();
                    kitchenObject.transform.SetParent(player.transform);
                    kitchenObject.transform.parent = player.GetKitchenObjectFollowTransform();
                    kitchenObject.transform.localPosition = Vector3.zero;
                    isDone = false;

                }
                

            }
        }

    }

    public void InterActAlter(Player player) 
    { 

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
