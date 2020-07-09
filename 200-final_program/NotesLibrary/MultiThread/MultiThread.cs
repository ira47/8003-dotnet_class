using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThread
{
    public class MultiLearning
    {
        public List<string> message = new List<string>();
        public Object locker = new Object();

        public void StartLearning(List<string> BookNames)
        {
            lock (locker)
                message.Add("开始执行多线程任务。。");
            ThreadPool.SetMaxThreads(2, 2);
            foreach (string bookName in BookNames)
            {
                ThreadPool.QueueUserWorkItem(LearningTask, bookName);
            }
        }

        public void LearningTask(object BookName)
        {
            string bookName = BookName.ToString();
            Random random = new Random();
            int n = random.Next(500, 1000);
            for (int count = 1; count <= 10; count++)
            {
                Thread.Sleep(n);
                string m = DateTime.Now.ToString() + " 书籍 " + bookName
                        + " 阅读到第 " + count.ToString() + " 页";
                lock (locker)
                    message.Add(m);
            }
        }
        public List<string> GetMessages()
        {
            lock (locker)
                return message;
        }
    }
}
