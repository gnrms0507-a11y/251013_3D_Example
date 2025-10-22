using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class Subject : MonoBehaviour
{
    //발행 대상 구독자 리스트
    private List<IObserver> observers = new List<IObserver>();  

    //구독 및 해제 기능

    public void AddObserver(IObserver Observer) => observers.Add(Observer);
    public void RemoveObserver(IObserver Observer) => observers.Remove(Observer);

    private void Start()
    {
        Notify();
    }

    private void Notify()
    {
        foreach(IObserver observer in observers)
        {
            observer.OnNotify();
        }
    }
}
