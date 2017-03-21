using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointCommon.RepositoryInterfaces;

namespace CheckPointPresenters.Presenters
{
    public class ManageAttendancePresenter : PresenterBase
    {
        private readonly IManageAttendanceView _view;
        private readonly IManageAttendanceModel _model;
        private readonly IUnitOfWork _unitOfWork;

        public ManageAttendancePresenter(IManageAttendanceView view, IManageAttendanceModel model, IUnitOfWork unitOfWork)
        {
            _view = view;
            _model = model;
            _unitOfWork = unitOfWork;
        }
    }
}
