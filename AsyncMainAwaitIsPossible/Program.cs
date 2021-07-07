using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMainAwaitIsPossible
{
    class Program
    {
        static async Task Main()
        {
            "This is async method Main with await in scope".PrintLine();
            for (int i = 0; i < 3; ++i) await Task.Run(Demo);
            List<Task> tasks = new();
            for (int i = 0; i < 7; ++i) 
                tasks.Add(Task.Factory.StartNew(Demo));
            Task.WaitAll(tasks.ToArray());
            "\nThe end of method Main".PrintLine();
        }

        static void Demo()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            int color = threadId % 15 + 1;
            $"Start Demo threadId {threadId}".PrintLine(color);
            for (int i = 0; i < 30; ++i)
            {
                Thread.Sleep(100);
                ". ".Print(color);
            }
            $"\nEnd Demo threadId {threadId}".PrintLine(color);
        }
    }
}
