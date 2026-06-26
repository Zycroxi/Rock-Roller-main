using UnityEngine;
using TMPro;

public class ZoneTextTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text zoneText;
    [SerializeField] private string zoneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zoneText.text = zoneName;
        }
    }
}
