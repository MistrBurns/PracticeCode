using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegates
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            var data = new ProcessData();
            //using Action<T>
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 5, myAction);
            data.ProcessAction(2, 5, myMultiplyAction);

            //using Funct<T, TResult> to implement BizRulesDelegate
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultDel = (x, y) => x * y;
            data.ProcessFunc(2, 5, funcAddDel);
            data.ProcessFunc(2, 5, funcMultDel);

            //using delegates for different method calls
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            data.Process(2,3, multiplyDel);


            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);
            //del1 += del2 + del3;


            //del1(5, WorkType.GenerateReports);

            //DoWork(del1);

            ////////////////////////////////

            var worker = new Worker();
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);
            //lamdba
            worker.WorkPerformed += (s,e) => Console.WriteLine(e.Hours + " " + e.WorkType);
            //delegate inference
            worker.WorkCompleted += worker_WorkCompleted;
            worker.DoWork(8,WorkType.GenerateReports);
        }
        /* now implemented via lambda
        static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine(e.Hours + " " + e.WorkType);
        }*/

        static void worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
        }
        //this is dynamic and can take any kind of WorkPerformedHandler delegate    
        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.GoToMeetings);
        //}

        //static void WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 " + hours.ToString());

        //}
        //static void WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 " + hours.ToString());

        //}
        //static void WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 " + hours.ToString());

        //}
      
    }
}
