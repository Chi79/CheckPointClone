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
   public class ApplyToCoursePresenter: PresenterBase
    {
        private readonly IApplyToCourseModel _model;
        private readonly IApplyToCourseView _view;
    

        public ApplyToCoursePresenter( IApplyToCourseView view, IApplyToCourseModel model)
        {
            _model = model;
            _view = view;
        }
       
        public override void FirstTimeInit()
        {
           
            ShowData();
        }
  
        public override void Load()
        {
       
            WireUpEvents();

        }
        private void ShowData()
        {
            ShowSelectedCourse();

            ShowAppointmentData();

            _view.BindData();

        

        }

        public void ShowMessagePanel()
        {
            _view.MessagePanelVisible = true;
        }
        private void ShowSelectedCourse()
        {

            _view.SetDataSource = _model.GetSelectedCourse();

            _view.SetDataSource2 = _model.GetEmptyCourseList();

        }
        private void ShowAppointmentData()
        {

            _view.SetDataSourceAppointmentData = _model.GetAppointmentsInCourse();

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyAppointmentList();

        }
        public void WireUpEvents()
        {
            _view.SortColumnsByPropertyAscending += OnSortColumnsAscendingClicked;
            _view.SortColumnsByPropertyDescending += OnSortColumnsDescendingClicked;

            _view.ApplyToCourse_Click += OnbtnApplyToCourse_Click;
            _view.Cancel_Click += OnCancel_Click;
            _view.Continue_Click += OnContinue_Click;
            _view.Yes_Click += OnYes_Click;
            _view.No_Click += OnNo_Click;
            
        }

        
        

        private void OnNo_Click(object sender, EventArgs e)
        {
            ShowDefaultButtons();
       
        }

        private void OnYes_Click(object sender, EventArgs e)
        {
            _model.PerformJob();
            CheckChangesSaved();

        }
        private void CheckChangesSaved()
        {

            bool UpdateSuccessful = _model.UpdateDatabaseWithChanges();
            if (UpdateSuccessful)
            {
               
                _view.Message = _model.GetJobCompletedMessage();
                
               

            }
            else
            {
                _view.Message = "Failed to attend course!" + _model.GetUpdateErrorMessage();
            }

            ShowContinueButtonOnMessagePanel();

        }
    

        private void OnContinue_Click(object sender, EventArgs e)
        {
            ShowDefaultButtons();
        }

        private void OnCancel_Click(object sender, EventArgs e)
        {
            _view.RedirectToFindPublicCourses();
        }

        private void OnbtnApplyToCourse_Click(object sender, EventArgs e)
        {
            
            bool appointmentsInCourse = _model.AppointmentsInCourse();

            if(appointmentsInCourse)
            {
              
                 ShowDecitionButtonsOnMessagePanel();
                _model.PrepareCreateMultipleAttendeesJob();
         
                _view.Message = _model.GetJobConfirmationMessage();
               
            }
            else
            {
                ShowContinueButtonOnMessagePanel();
                _view.Message = "There are no appointments to attend in this course!";
            }
   
        }
        private void ShowDecitionButtonsOnMessagePanel()
        {
            _view.MessagePanelVisible = true;
            _view.BtnCancelVisible = false;
            _view.BtnApplyToCourseVisible = false;
            _view.BtnContinueVisible = false;
            _view.BtnNoVisible = true;
            _view.BtnYesVisible = true;

        }
        private void ShowContinueButtonOnMessagePanel()
        {
            _view.MessagePanelVisible = true;
            _view.BtnContinueVisible = true; 
            _view.BtnCancelVisible = false;
            _view.BtnApplyToCourseVisible = false;
            _view.BtnNoVisible = false;
            _view.BtnYesVisible = false;
        }
    private void ShowDefaultButtons()
        {            
            _view.Message = string.Empty;
            _view.MessagePanelVisible = false;
            _view.BtnContinueVisible = false;
            _view.BtnCancelVisible = true;
            _view.BtnApplyToCourseVisible = true;
            _view.BtnNoVisible = false;
            _view.BtnYesVisible = false;
        }       

    
        private void OnSortColumnsAscendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsInCourseSortedByPropertyAsc();

            _view.SetDataSourceAppointmentData = apps;

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyAppointmentList();

            ShowSelectedCourse();

            _view.BindData();



        }

        private void OnSortColumnsDescendingClicked(object sender, EventArgs e)
        {

            var apps = _model.GetAppointmentsInCourseSortedByPropertyDesc();

            _view.SetDataSourceAppointmentData = apps;

            _view.SetDataSourceAppointmentHeader = _model.GetEmptyAppointmentList();

            ShowSelectedCourse();

            _view.BindData();



        }


    }
}
