using DllSky.Components.Services;
using UnityEngine;

namespace Test
{
    public class TestAutoLocator : AutoLocatorComponent
    {
        [SerializeField] private int _amount1;
        [SerializeField] private int _amount2;
        [SerializeField] private bool _flag;
    }
}
