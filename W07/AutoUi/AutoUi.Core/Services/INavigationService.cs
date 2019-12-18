using System;
using System.Collections.Generic;
using System.Text;

namespace AutoUi.Core.Services
{
    public interface INavigationService
    {
        void Show<T>(T vm);
    }
}
