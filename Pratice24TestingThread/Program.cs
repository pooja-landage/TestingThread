using System;
using System.Threading;
namespace Pratice24TestingThread
{
    public class TestingThread
    {
        public void FunctionCall()
        {
            for (int x = 0; x <= 5; x++)
            {
                Console.WriteLine(x);
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("===Main Calling Child Thread====");
            TestingThread tt = new TestingThread();
            ThreadStart ts = new ThreadStart(tt.FunctionCall);
            Thread t1 = new Thread(ts);
            Console.WriteLine("Thread State : {0}", t1.ThreadState);

            t1.Start();
            Console.WriteLine("Thread State : {0}", t1.ThreadState);

            try
            {
                t1.Suspend();
            }

            catch (PlatformNotSupportedException )
            {
                Console.WriteLine("Not supported");
            }
            Console.WriteLine("Thread State : {0}", t1.ThreadState);

            try
            {
                t1.Resume();
            }
            catch(PlatformNotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Thread State : {0}", t1.ThreadState);
            }
        }
    }
}
