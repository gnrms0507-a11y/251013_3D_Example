
public interface IPlayerOberver 
{
    public void OnPlayerHpChanged(float currentHp , float MaxHp);
}

public interface IPlayTimer
{
    public void OnPlayerTime();
}

public interface IKillEnemy
{
    public void OnKillEnemy();
}