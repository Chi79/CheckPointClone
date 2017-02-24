using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.RepositoryInterfaces;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data;
using DataAccess.Concrete.Repositories;
using CheckPointCommon.Structs;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork  //specific to our app
    {
        private readonly CheckPointContext _context;   //stores ref to our dbcontext

        public UnitOfWork(CheckPointContext context)   
        {
            _context = context;

            CLIENTs = new ClientRepository(_context);    //and uses our dbcontext to intiialize our repository

            APPOINTMENTs = new AppointmentRepository(_context);

            COURSEs = new CourseRepository(_context);

            ATTENDEEs = new AttendeeRepository(_context);
        }
        public IClientRepository CLIENTs { get; private set; }

        public IAppointmentRepository APPOINTMENTs { get; private set; }

        public ICourseRepository COURSEs { get; private set; }

        public IAttendeeRepository ATTENDEEs { get; private set; }

        //public int Complete()
        //{
        //    return _context.SaveChanges();
        //}
        public void Dispose()
        {
            _context.Dispose();
        }
        public SaveResult myComplete()
        {
            SaveResult SaveResult = new SaveResult { };
            SaveResult.Result = 0;
            SaveResult.ErrorMessage = string.Empty;

            try
            {
                SaveResult.Result = _context.SaveChanges();
                return SaveResult;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {

                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var validation_error in error.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            validation_error.PropertyName, validation_error.ErrorMessage);
                    }
                }
                SaveResult.ErrorMessage = e.Message;
                return SaveResult;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.InnerException);

                System.Data.Entity.Core.UpdateException update_error = (System.Data.Entity.Core.UpdateException)e.InnerException;
                System.Data.SqlClient.SqlException error = (System.Data.SqlClient.SqlException)update_error.InnerException;

                SaveResult.ErrorMessage = error.Message;
                return SaveResult;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                SaveResult.ErrorMessage = e.Message;
                return SaveResult;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                SaveResult.ErrorMessage = e.Message;
                return SaveResult;
            }
        }
    }
}
