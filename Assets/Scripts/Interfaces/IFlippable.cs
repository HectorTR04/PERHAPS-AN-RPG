using System;
using System.Collections;

namespace Assets.Scripts.Interfaces
{
    public interface IFlippable
    {
        event Action OnFlipped;

        IEnumerator Flip();

        bool IsFlipped { get; set; }
    }
}
