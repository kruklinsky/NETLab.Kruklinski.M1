using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace App_Code.Handlers
{
    public class CustomAsyncHandler : IHttpAsyncHandler
    {
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            AsynchOperation result = new AsynchOperation(cb, context, extraData);
            result.StartAsyncWork();
            return result;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new InvalidOperationException();
        }
    }

    class AsynchOperation : IAsyncResult
    {
        private bool completed;
        private Object state;
        private AsyncCallback callback;
        private HttpContext context;

        bool IAsyncResult.IsCompleted { get { return completed; } }
        WaitHandle IAsyncResult.AsyncWaitHandle { get { return null; } }
        Object IAsyncResult.AsyncState { get { return state; } }
        bool IAsyncResult.CompletedSynchronously { get { return false; } }

        public AsynchOperation(AsyncCallback callback, HttpContext context, Object state)
        {
            this.callback = callback;
            this.context = context;
            this.state = state;
            this.completed = false;
        }

        public void StartAsyncWork()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(StartAsyncTask), null);
        }

        private void StartAsyncTask(Object workItemState)
        {
            this.context.Response.ContentType = "aplication/json";
            this.context.Response.WriteFile("~/App_Data/data.json");
            this.completed = true;
            this.callback(this);
        }
    }
}