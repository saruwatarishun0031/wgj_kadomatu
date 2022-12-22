using UnityEngine.UI;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    [SerializeField]
    [Header("クレジットのキャンバス")]
    Canvas _cureditCanvas;

    private void Start()
    {
        _cureditCanvas.enabled = false;
    }
    public void OnCredit()
    {
        _cureditCanvas.enabled = true;
    }

    public void OffCredit()
    {
        _cureditCanvas.enabled = false;
    }
}
