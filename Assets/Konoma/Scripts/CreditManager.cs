using UnityEngine.UI;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    [SerializeField]
    [Header("クレジットのキャンバス")]
    Canvas _cureditCanvas;

    public void OnCredit()
    {
        _cureditCanvas.enabled = true;
    }

    public void OffCredit()
    {
        _cureditCanvas.enabled = false;
    }
}
