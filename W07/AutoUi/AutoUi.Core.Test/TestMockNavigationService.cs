using System.Collections.Generic;
using AutoUi.Core.Services;

namespace AutoUi.Core.Test
{
    public class TestMockNavigationService : INavigationService
    {
        public Stack<string> ViewStack { get; } = new Stack<string>();

        public void Show<T>(T vm)
        {
            ViewStack.Push(typeof(T).Name);
        }
    }
}
