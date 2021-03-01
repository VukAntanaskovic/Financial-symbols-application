using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEtest.API
{
    public interface IApiCallback
    {
        void showLoading();
        void hideLoading();

        void onGetResult(string result);

        void onErrorResult(string message);
    }
}
