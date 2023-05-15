using System;

public interface IGameElement
{
    public void OnGameStart(Action callback);
    public void OnGameStop();
}