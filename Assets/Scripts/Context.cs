/*  
 *  Utilizes Singleton Pattern.
 *  Holds current state.
 *  Can get and set state.
 */
public class Context
{
    private IState state;
    private static Context obj;

    private Context()
    {
        state = null;
    }

    public static Context GetInstance()
    {
        if (obj == null)
        {
            obj = new Context();
        }
        return obj;
    }
    
    // Method to get game state.
    public IState GetState()
    {
        return state;
    }

    // Method to set game state.
    public void SetState(IState state)
    {
        this.state = state;		
    }
}
