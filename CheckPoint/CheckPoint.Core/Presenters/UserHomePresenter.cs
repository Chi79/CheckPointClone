using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointPresenters.Bases;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class UserHomePresenter : PresenterBase
    {
        private readonly IUserHomeModel _userHomeModel;
        private readonly IUserHomeView _userHomeVIew;

        public UserHomePresenter(IUserHomeModel userHomeModel, IUserHomeView userHomeView)
        {
            _userHomeModel = userHomeModel;
            _userHomeVIew = userHomeView;

            _userHomeVIew.Message = "Welcome User!   Our Homepage is coming soon....";
        }
    }
}
