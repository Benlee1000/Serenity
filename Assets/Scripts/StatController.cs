using TMPro;
using UnityEngine;

/*  
 *  Controller for stats ui
 *  Can set attack, defense, and speed text
 */
public class StatController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AttackText;
    [SerializeField] TextMeshProUGUI DefenseText;
    [SerializeField] TextMeshProUGUI SpeedText;

    // Start is called before the first frame update
    void Start()
    {
        // Stats should be set to saved values
        AttackText.text = PlayerPrefs.GetInt("Attack").ToString();
        DefenseText.text = PlayerPrefs.GetInt("Defense").ToString();
        SpeedText.text = PlayerPrefs.GetInt("Speed").ToString();
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
