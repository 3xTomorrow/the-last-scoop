using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private Transform chairT;

    private const string IS_SITTING = "isSitting";

    private Animator bossAnim;
    private Transform bossT;


    private void Awake()
    {
        bossT = GetComponent<Transform>();
        bossAnim = GetComponentInChildren<Animator>();
    }

    public void SitDown()
    {
        bossT.position = chairT.position;
        bossT.rotation = chairT.rotation;
        bossAnim.SetBool((IS_SITTING), true);
    }
}
