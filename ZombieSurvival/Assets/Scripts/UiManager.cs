using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Text ammoText;
    public Text waveInfoText;
    private void OEnable()
    {
        SetAmmoText(0, 0);
    }
    public void SetAmmoText(int magAmmo, int remainAmmo)
    {
        ammoText.text = $"{magAmmo} / {remainAmmo}";
    }
        public void SetWaveText(int wave, int count)
    {
        waveInfoText.text = $"Wave: {wave} \nEnemy Left {count}";
    }
}

