/*  
 *  Static class, only one instance
 *  Holds and can modify upgrades of the player:
 *  Attack
 *  Defense
 *  Speed
 *  Weapon
 *  
 *  Could possibly store this data in a txt file for saving and continuing game
 *  Maybe when a save button is clicked, or before the window is closed?
 */
public static class Scores
{
    private static int attack;
    private static int defense;
    private static int speed;
    private static int dashSpeed;

    // Might be unused
    private static int dashDamage;
    
    // Method to get player upgrades
    public static int GetAttack()
    {
        return attack;
    } 

    public static int GetDefense()
    {
        return defense;
    }

    public static int GetSpeed()
    {
        return speed;
    }

    public static int GetDashSpeed()
    {
        return dashSpeed;
    }

    // Method to set player upgrades
    public static void SetAttack(int atk)
    {
        attack = atk;
    }

    public static void SetDefense(int def)
    {
        defense = def;
    }

    public static void SetSpeed(int spd)
    {
        speed = spd;
    }

    public static void SetDashSpeed(int dashSpd)
    {
        dashSpeed = dashSpd;
    }
}
