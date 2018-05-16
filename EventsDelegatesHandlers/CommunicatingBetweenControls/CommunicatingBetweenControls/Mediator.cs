using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicatingBetweenControls.Model;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        //static member for singleton funcionality
        private static Mediator instance;
        private Mediator() { }
        public static Mediator GetInstance()
        {
            if (instance == null)
                instance = new Mediator();
            return instance;
        }

        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged (object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
                jobChangedDelegate(sender, new JobChangedEventArgs {Job = job});
        }
    }
}
