using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Text ammoText;
    private void OEnable()
    {
        SetAmmoText(0, 0);
    }
    public void SetAmmoText(int magAmmo, int remainAmmo)
    {
        ammoText.text = $"{magAmmo} / {remainAmmo}";
    }
}
