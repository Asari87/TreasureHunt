using System;

public interface IGameElement
{
    public void OnGameStart(Action callback);
    public void OnGamePaused();
    public void OnGameResume();
    public void OnGameStop();
}