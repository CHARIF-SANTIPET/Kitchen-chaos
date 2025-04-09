using UnityEngine;

public class ChopChop : MonoBehaviour
{
    [SerializeField] AudioSource chop;
    public float knifeSpeed = 0.2f; // ความเร็วในการทำงานของ Cutting_FX
    private float timer = 0f;
    public float delayTime = 5f; // ดีเลย์ทุกๆ 5 วินาที
    private Animator animator;

    private int cutCount = 0;
    private bool isCutting = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // เช็คว่าถึงเวลาทำงานรึยัง
        if (timer >= delayTime)
        {
            isCutting = true;
            cutCount = 0;  // เริ่มต้นใหม่
            timer = 0f;
        }

        // ถ้าอยู่ในช่วงการทำงาน 4 ครั้ง
        if (isCutting && cutCount < 4)
        {
            Cutting_FX(Time.deltaTime);
        }
    }

    private void Cutting_FX(float duration)
    {
        timer += duration;

        // ทำงานทุกๆ knifeSpeed วินาที
        if (timer >= knifeSpeed)
        {
            chop.Play();
            animator.SetTrigger("Cut");
            timer = 0f;
            cutCount++;

            // ถ้าทำงานครบ 4 ครั้งแล้วก็หยุด
            if (cutCount >= 4)
            {
                isCutting = false;
            }
        }
    }
}
