using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CustomDelegates.Program;

namespace CustomDelegates
{
    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
    //Set up delegate
    //public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
    
    class Worker
    {
        //Set up events
        //alternative to delegate is using generic EventHandler<T>
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;
       
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                //Raise Event
                OnWorkPerformed(i + 1, workType);
            }
            //Raise Event
            OnWorkCompleted();
        }
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
                del(hours, new WorkPerformedEventArgs(hours, workType));
        }
        protected virtual void OnWorkCompleted()
        {
            EventHandler del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
