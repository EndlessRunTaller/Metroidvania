[System.Serializable]
public class PlayerData
{
    public int scene;

    public PlayerData(FPSController fPSController)
    {
        scene = fPSController.scene;
    }

}
