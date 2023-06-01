using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AttackText;
    [SerializeField] TextMeshProUGUI DefenseText;
    [SerializeField] TextMeshProUGUI SpeedText;

    // Start is called before the first frame update
    void Start()
    {
        AttackText.text = "0";
        DefenseText.text = "1";
        SpeedText.text = "2";
    }

    public void setAttackText(int attack)
    {
        AttackText.text = attack.ToString();
    }
    public void setDefenseText(int attack)
    {
        AttackText.text = attack.ToString();
    }
    public void setSpeedText(int attack)
    {
        AttackText.text = attack.ToString();
    }

}
