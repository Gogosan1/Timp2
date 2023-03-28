/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.contracts
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;
        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;
        void Run<TPresenter>()
            where TPresenter : class, IPresenter;
    }
}*/
